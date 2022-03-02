## Macro Deck Extension Store

### Add your plugin to the Extension Store
1. Fork this repository
2. Create a new folder in the `Plugins` folder, called like the root namespace of your plugin (For example `SuchByte.TwitchPlugin`)
3. Add the source code of the plugin (which contains the .csproj file) to this folder
4. Create a `ExtensionManifest.json` containing following json data:
```json
{
  "name" : "NameOfYourPlugin",
  "author" : "You",
  "repository" : "https://github.com/you/Your-Repository",
  "packageId" : "YourRoot.Namespace",
  "version" : "1.0.0",
  "target-plugin-api-version" : 31
}

```
5. Create a pull-request of your fork of this repository

You can take this as a example how the folder with your plugin's source should look like: https://github.com/SuchByte/Macro-Deck-Extensions/tree/main/Plugins/SuchByte.TwitchPlugin
___
### Add your icon pack to the Extension Store
### Coming soon!
