## Add new Plugin ##
If you need to add a submodule that isn't currently
in the repository, then it needs to be added as a remote
reference.

### Command ###
Start at Project Root
```
> git submodule add <plugin http clone url> Plugins\<package id>
```

### Example ####
for RecklessBoon's GPU-Z plugin

| replacement name      | example value
| --------------------- | ----------------------------------------------------------- |
| plugin http clone url | https://github.com/RecklessBoon/Macro-Deck-GPU-Z-Plugin.git |
| package id            | RecklessBoon.MacroDeck.GPUZ                                 |
```
> git submodule add https://github.com/RecklessBoon/Macro-Deck-GPU-Z-Plugin.git Plugins\RecklessBoon.MacroDeck.GPUZ
```

### Further Explanation ###
This will pull the remote repository into a new folder inder Plugins named as your Package Id.

--------

## Selecting branch/tag/commit for plugin ##
Once you have a plugin repository added as a submodule, 
you can interact with it exactly as you would with a normal
repository (from the command line). This means when you 
are in the submodule directory, you can run normal git
commands.

### Command ###
Starting at Project Root
```
> cd Plugins\<package id>
> git checkout <treeish>
> cd ..\..
```

### Example ###
for RecklessBoon's GPU-Z plugin

| replacement name      | example value
| --------------------- | ----------------------------------------------------------- |
| plugin http clone url | https://github.com/RecklessBoon/Macro-Deck-GPU-Z-Plugin.git | 
```
> cd Plugins\RecklessBoon.MacroDeck.GPUZ
> git checkout v1.0.4
> cd ..\..
```

> *NOTE*: In the example above, a tag is being checked out
and git will warn you that you are on a "detached HEAD" which
is normal and expected. This just means you are not on a branch.

### Further Explanation ###
Doing this step will set the commit that the extensions
repository will save for the submodule in its git
object databse. This commit is what will be pulled by
the extensions repository when `git submodule update` 
is run to pull the correct submodule versions
