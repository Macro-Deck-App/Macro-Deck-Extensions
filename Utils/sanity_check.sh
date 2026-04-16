#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
VALIDATOR="$SCRIPT_DIR/validate_extension.sh"

if [[ ! -x "$VALIDATOR" ]]; then
  chmod +x "$VALIDATOR"
fi

if [[ -z "${output_path:-}" || -z "${package_id:-}" ]]; then
  echo "::error::Missing required environment variables: output_path and package_id"
  exit 1
fi

args=(--extension-path "./${output_path}/${package_id}")

if [[ -n "${ext_type:-}" ]]; then
  args+=(--ext-type "$ext_type")
fi

if [[ -n "${current_hash:-}" ]]; then
  args+=(--previous-ref "$current_hash")
fi

"$VALIDATOR" "${args[@]}"
