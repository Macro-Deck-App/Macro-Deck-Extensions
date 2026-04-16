#!/usr/bin/env bash
set -euo pipefail

usage() {
  echo "Usage: $0 --extension-path <path> [--ext-type Plugin|IconPack] [--previous-ref <git-ref>]"
}

error() {
  echo "::error::$1"
  HAS_ERRORS=1
}

extract_version_from_file() {
  sed -n 's:.*<Version>\([^<]*\)</Version>.*:\1:p' "$1" | head -n 1
}

extract_version_from_text() {
  printf '%s\n' "$1" | sed -n 's:.*<Version>\([^<]*\)</Version>.*:\1:p' | head -n 1
}

EXTENSION_PATH=""
EXT_TYPE=""
PREVIOUS_REF=""

while [[ $# -gt 0 ]]; do
  case "$1" in
    --extension-path)
      EXTENSION_PATH="$2"
      shift 2
      ;;
    --ext-type)
      EXT_TYPE="$2"
      shift 2
      ;;
    --previous-ref)
      PREVIOUS_REF="$2"
      shift 2
      ;;
    -h|--help)
      usage
      exit 0
      ;;
    *)
      usage
      echo "Unknown argument: $1"
      exit 1
      ;;
  esac
done

if [[ -z "$EXTENSION_PATH" ]]; then
  usage
  echo "Missing required argument --extension-path"
  exit 1
fi

if [[ ! -d "$EXTENSION_PATH" ]]; then
  echo "::error::Extension path not found: $EXTENSION_PATH"
  exit 1
fi

cd "$EXTENSION_PATH"
HAS_ERRORS=0

if [[ ! -f "ExtensionManifest.json" ]]; then
  echo "::error::Missing ExtensionManifest.json"
  exit 1
fi

MANIFEST_VERSION="$(jq -r '.version // empty' ExtensionManifest.json)"
MANIFEST_TYPE="$(jq -r '.type // empty' ExtensionManifest.json)"

if [[ -z "$MANIFEST_VERSION" ]]; then
  error "ExtensionManifest.json 'version' key does not exist"
fi

if [[ -z "$EXT_TYPE" ]]; then
  if [[ "$MANIFEST_TYPE" == "Plugin" ]]; then
    EXT_TYPE="Plugin"
  else
    EXT_TYPE="IconPack"
  fi
fi

if [[ -n "$PREVIOUS_REF" ]]; then
  OLD_MANIFEST_VERSION="$(git show "${PREVIOUS_REF}:ExtensionManifest.json" 2>/dev/null | jq -r '.version // empty' || true)"
  if [[ -n "$OLD_MANIFEST_VERSION" && -n "$MANIFEST_VERSION" && "$OLD_MANIFEST_VERSION" == "$MANIFEST_VERSION" ]]; then
    error "ExtensionManifest.json 'version' key was not updated"
  fi
fi

# Block known executable payloads in extension repositories.
SUSPICIOUS_FILES=()
while IFS= read -r file; do
  [[ -n "$file" ]] && SUSPICIOUS_FILES+=("$file")
done < <(find . -type f \( \
  -iname '*.dll' -o \
  -iname '*.exe' -o \
  -iname '*.bat' -o \
  -iname '*.cmd' -o \
  -iname '*.com' -o \
  -iname '*.msi' -o \
  -iname '*.msp' -o \
  -iname '*.scr' -o \
  -iname '*.pif' -o \
  -iname '*.ps1' -o \
  -iname '*.psm1' -o \
  -iname '*.vbs' -o \
  -iname '*.vbe' -o \
  -iname '*.wsf' -o \
  -iname '*.wsh' -o \
  -iname '*.sh' -o \
  -iname '*.appimage' -o \
  -iname '*.bin' -o \
  -iname '*.run' \
\) -not -path './.git/*' | sort)

if [[ ${#SUSPICIOUS_FILES[@]} -gt 0 ]]; then
  error "Suspicious executable files are not allowed in extensions:"
  for file in "${SUSPICIOUS_FILES[@]}"; do
    echo "::error file=${file#./}::Forbidden executable file found"
  done
fi

if [[ "$EXT_TYPE" == "Plugin" ]]; then
  CSPROJ_FILES=()
  while IFS= read -r file; do
    [[ -n "$file" ]] && CSPROJ_FILES+=("$file")
  done < <(find . -type f -name '*.csproj' -not -path './.git/*' | sort)

  if [[ ${#CSPROJ_FILES[@]} -eq 0 ]]; then
    error "No .csproj file found for Plugin extension"
  fi

  for csproj in "${CSPROJ_FILES[@]}"; do
    NEW_CSPROJ_VERSION="$(extract_version_from_file "$csproj" || true)"

    if [[ -z "$NEW_CSPROJ_VERSION" ]]; then
      error "${csproj#./} does not contain a <Version> node"
      continue
    fi

    if [[ -n "$MANIFEST_VERSION" && "$NEW_CSPROJ_VERSION" != "$MANIFEST_VERSION" ]]; then
      error "ExtensionManifest.json version '$MANIFEST_VERSION' does not match ${csproj#./} version '$NEW_CSPROJ_VERSION'"
    fi

    if [[ -n "$PREVIOUS_REF" ]]; then
      RELATIVE_CSPROJ="${csproj#./}"
      OLD_CSPROJ_CONTENT="$(git show "${PREVIOUS_REF}:${RELATIVE_CSPROJ}" 2>/dev/null || true)"
      if [[ -n "$OLD_CSPROJ_CONTENT" ]]; then
        OLD_CSPROJ_VERSION="$(extract_version_from_text "$OLD_CSPROJ_CONTENT" || true)"
        if [[ -n "$OLD_CSPROJ_VERSION" && "$OLD_CSPROJ_VERSION" == "$NEW_CSPROJ_VERSION" ]]; then
          error "${RELATIVE_CSPROJ} <Version> was not updated"
        fi
      fi
    fi
  done
fi

if [[ "$HAS_ERRORS" -ne 0 ]]; then
  exit 1
fi

echo "Validation passed for $EXTENSION_PATH"



