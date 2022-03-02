Add your plugin to the Extension Store
Fork this repository
Create a new folder in https://github.com/SuchByte/Macro-Deck-Extensions/tree/main/Plugins called like the root namespace of your plugin (For example SuchByte.TwitchPlugin)
Add the source code of the plugin (which contains the .csproj file) to this folder
Create a ExtensionManifest.json containing following json data:
{
  "name" : "NameOfYourPlugin",
  "author" : "You",
  "repository" : "https://github.com/you/Your-Repository",
  "packageId" : "YourRoot.Namespace",
  "version" : "1.0.0",
  "target-plugin-api-version" : 31
}
Create a pull-request of your fork of this repository
You can take this as a example how the folder with your plugin's source should look like: https://github.com/SuchByte/Macro-Deck-Extensions/tree/main/Plugins/SuchByte.TwitchPlugin
