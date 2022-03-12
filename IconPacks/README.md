### Add your icon pack to the Extension Store
## Important
When choosing a package id, make sure you follow this rules:
- No whitespaces
- Example: MacroDeck.MacroDeckcolorfulgenericicons

To publish your icon pack in the Macro Deck extension store, you have to create a GitHub repository for your icon pack.

1. Make sure, your icon pack repository tree looks like this:
    - (Optional) `ExtensionIcon.png` (64x64px)
    - `SomeIcon.png`
    - `AnotherIcon.png`
    .
    .
    .
    - `ExtensionManifest.json`
        - This should contain following json data:
            ```json
              {
                "type" : "IconPack",
                "name" : "NameOfYourIconPack",
                "author" : "You",
                "repository" : "https://github.com/you/Your-Repository",
                "packageId" : "You.NameOfYourIconPack",
                "version" : "1.0.0",
                "target-plugin-api-version" : 31
              }
        Take this as example: https://github.com/SuchByte/Macro-Deck-Colorful-Generic-Icons

2. Fork this repository

3. If not added yet, add submodule from project root: `git submodule add <clone url> Plugins/<packageId>`
    - Example: `git submodule add https://github.com/SuchByte/Macro-Deck-Extensions IconPacks/MacroDeck.MacroDeckcolorfulgenericicons`
    
4. Update the commit: `cd .\IconPacks\<packageId>\; git fetch; git checkout <branch/tag/commit sha1>; cd ..\..`
    - For example `cd .\IconPacks\MacroDeck.MacroDeckcolorfulgenericicons\; git fetch; git checkout v1.0.4; cd ..\..`           
    
5. Commit the changes: `git commit -a -m "Changes"`

6. Push the commit: `git push`

7. Create a pull-request
