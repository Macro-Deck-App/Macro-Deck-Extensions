## Macro Deck Extension Store
This repository is the build manifest for the Macro Deck 2 Extension Store.

All artifacts to include in Macro Deck must be pulled into this repository for building/packaging.

### How to publish your content

### Prerequirements
- You need a repository for your Extension (for Plugins AND IconPacks)
- You need to choose a package id
  >When choosing a package id, make sure you follow this rules:
  >- No whitespaces
  >- Use the format YourName.YourExtensionName
      
   Example: SuchByte.MacroDeckcolorfulgenericicons
- Your Extension needs a ExtensionManifest.json file which should look like this:
```json
{
   "type" : "Plugin|IconPack",
   "name" : "NameOfYourExtension",
   "author" : "You",
   "repository" : "https://github.com/you/Your-Repository",
   "packageId" : "YourName.ExtensionName",
   "version" : "1.0.0",
   "target-plugin-api-version" : 36,
   "dll" : "My Plugin.dll"
}
```

### Repository root file structure
#### Plugins
```
ExtensionManifest.json
MyPlugin.csproj
ExtensionIcon.png
MyPlugin.cs
.
.
.
```
#### Icon Packs
```
ExtensionManifest.json
ExtensionIcon.png
MyIcon1.png
SomeotherIcon.png
.
.
.
```

### Rules
#### General
- Do not add files directly to this repository
  > Use the workflow to automatically add the extension as submodule
#### Plugins
- No .dll files as dependencies are allowed
- Make sure you have the rights to use your used libraries
#### Icon Packs
- Make sure you have the rights to use and publish the added icons

### Add your Extension to the Extension Store
1. Fork this repository
2. On your fork, click on the `Actions` tab
3. Click on the `Add/Update Extension` workflow

   > **Note:** if on mobile click the `Select workflow` button first
   
4. Click on `Run workflow` button
5. Fill in the details and click the green `Run workflow` button under the fields
6. Open the PR that is created, accept and merge it
7. On your main branch, create a PR to the parent repository
  - This is required due to permissions via actions being more strict than the web UI
