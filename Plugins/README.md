### Add your plugin to the Extension Store
1. Make sure, your original plugin repoistory contains this files:
    - `YOUR_PLUGIN.csproj`
    - `ExtensionIcon.png` (64x64px)
    - `ExtensionManifest.json`
        - This should contain following json data:
            ```json
              {
                "type" : "Plugin",
                "name" : "NameOfYourPlugin",
                "author" : "You",
                "repository" : "https://github.com/you/Your-Repository",
                "packageId" : "YourRoot.Namespace",
                "version" : "1.0.0",
                "target-plugin-api-version" : 31,
                "dll" : "My Plugin.dll"
              }

2. Fork this repository

3. If not added yet, add submodule from project root: `git submodule add <clone url> Plugins/<packageId>`
    - Example: `git submodule add https://github.com/SuchByte/Macro-Deck-Extensions Plugins/RecklessBoon.MacroDeck.GPUZ`
    
4. Update the commit: `cd .\Plugins\<packageId>\; git fetch; git checkout <branch/tag/commit sha1>; cd ..\..`
    - For example `cd .\Plugins\RecklessBoon.MacroDeck.GPUZ\; git fetch; git checkout v1.0.4; cd ..\..`           
    
5. Commit the changes: `git commit -a -m "Changes"`

6. Push the commit: `git push`

7. Create a pull-request
