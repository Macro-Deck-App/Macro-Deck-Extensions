### Add your plugin to the Extension Store
1. In your original plugin repository, create or update a `ExtensionManifest.json` containing following json data:
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

2. Fork this repository
3. Follow one of these processes
    A. Manual Process
        1. Create a new folder in the `Plugins` folder, called like the root namespace of your plugin (For example `SuchByte.TwitchPlugin`)
        2. Add the source code of the plugin (which contains the .csproj file) to this folder
    B. Use Git Submodule
        1. If not added yet, add submodule from project root: `git submodule <clone url> Plugins/<packageId>`
        2. Update the commit to use: `cd .\Plugins\<packageId>\; git fetch; git checkout <branch/tag/commit sha1>; cd ..\..`
            - For example `cd .\Plugins\RecklessBoon.MacroDeck.GPUZ\; git fetch; git checkout v1.0.4; cd ..\..`
4. Commit & create a pull-request of your fork of this repository

You can take this as a example how the folder with your plugin's source should look like: https://github.com/SuchByte/Macro-Deck-Extensions/tree/main/Plugins/SuchByte.TwitchPlugin
