#!/bin/bash
cd "./${{ env.output_path }}/${{ env.package_id }}"
if [ ! -z "${{ env.current_hash }}" ]; then
  result=0

  # ExtensionManifest.json check
  old_manifest_version=$(git cat-file -p ${{ env.current_hash }}:ExtensionManifest.json | jq -r '[.version][0]')
  new_manifest_version=$(git cat-file -p HEAD:ExtensionManifest.json | jq -r '[.version][0]')
  if [ $old_manifest_version == $new_manifest_version ]; then
    echo "::error::ExtensionManifest.json 'version' key was not updated"
    result=1
  fi

  if [ ${{ env.ext_type }} = 'Plugin' ]; then 
    # csproj check
    old_csproj_version=$(git cat-file -p ${{ env.current_hash }}:$(ls *.csproj | head -n 1) | grep -oPm1 "(?<=<Version>)[^<]+")
    new_csproj_version=$(git cat-file -p HEAD:$(ls *.csproj | head -n 1) | grep -oPm1 "(?<=<Version>)[^<]+")
    if [ $old_csproj_version == $new_csproj_version ]; then
      echo "::error::csproj file 'version' node was not updated"
      result=1
    fi

    # ExntensionManifest <-> csproj check
    if [ ! -z $new_manifest_version ] && [ ! -z $new_csproj_version ] && [ $new_manifest_version != $new_csproj_version ]; then
      echo "::error::ExtensionManifest.json 'version' token does not match the csproj file's 'Version' node"
      result=1
    fi
  fi

  if [ $result -ne 0 ]; then
    exit 1
  fi
else
  result=0

  # Manifest check
  manifest_version="$(git cat-file -p HEAD:ExtensionManifest.json | jq -r '[.version][0]')"
  if [ -z manifest_version ]; then 
    echo "::error::ExtensionManifest.json 'version' key does not exist"
    result=1
  fi

  if [ ${{ env.ext_type }} = 'Plugin' ]; then 
    # csproj check
    csproj_version="$(git cat-file -p HEAD:$(ls *.csproj | head -n 1) | grep -oPm1 "(?<=<Version>)[^<]+")"
    if [ -z csproj_version ]; then
      echo "::error::csproj file 'version' key does not exist"
      result=1
    fi

    # ExntensionManifest <-> csproj check
    if [ ! -z $manifest_version ] && [ ! -z $csproj_version ] && [ $manifest_version != $csproj_version ]; then
      echo "::error::ExtensionManifest.json 'version' token does not match the csproj file's 'Version' node"
      result=1
    fi
  fi

  if [ $result -ne 0 ]; then
    exit 1
  fi
fi
cd ../..
