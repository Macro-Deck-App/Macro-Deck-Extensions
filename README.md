## Macro Deck Extension Store

> [!IMPORTANT]
> **Macro Deck 2 plugin submissions are deprecated as of August 15, 2026.**
>
> New Macro Deck 2 plugins are no longer accepted. Existing Macro Deck 2 plugins may still receive updates during the transition period. If you are developing a new plugin, please target Macro Deck 3 instead.

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
   "name" : "NameOfYourExtension", (You can't change this in the future)
   "author" : "You",
   "repository" : "https://github.com/you/Your-Repository",
   "packageId" : "YourName.ExtensionName", (No whitespace and no special characters allowed, you can't change this in the future)
   "version" : "1.0.0", (Recommended format: Major.Minor.Patch)
   "target-plugin-api-version" : 40, (Find this in the Macro Deck settings)
   "target-macro-deck-version" : "1.13.0", (The current version you're using for development)
   "dll" : "My Plugin.dll" (Only required for plugins)
   "author-discord-userid": "9876545678765" (Optional: Your Discord user Id for support)
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
- **New Macro Deck 2 plugins are no longer accepted. Only updates to plugins already present in the store are allowed.**
- No .dll files as dependencies are allowed
- Make sure you have the rights to use your used libraries
#### Icon Packs
- Make sure you have the rights to use and publish the added icons

### Add or update your Extension in the Extension Store

> [!NOTE]
> For plugins, the workflow only accepts updates to plugins that are already present in the store. New Macro Deck 2 plugins are rejected automatically.

1. Fork this repository
2. On your fork, click on the `Actions` tab
3. Click on the `Add/Update Extension` workflow

   > **Note:** if on mobile click the `Select workflow` button first
   
4. Click on `Run workflow` button
5. Fill in the details and click the green `Run workflow` button under the fields
6. On your main branch, create a PR to the parent repository
  - This is required due to permissions via actions being more strict than the web UI
7. Your extension will be automatically checked and built. After that a moderator will approve your submission.
