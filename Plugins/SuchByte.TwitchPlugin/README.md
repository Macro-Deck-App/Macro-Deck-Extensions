# Twitch plugin for Macro Deck 2
Control Twitch using Macro Deck 2

## Features
| Action | Description |
| --- | --- |
| Set stream title/game | Sets the stream title and the game. (Optional with variables) |
| Clear chat | Clears the chat. |
| Play commercial | Plays a commercial. A Twitch Partner or Affiliate account is required! |
| Send chat message | Sends the configured message in the chat. (Optional with variables) |
| Followers only chat | Enables/disables the followers only chat. |
| Slow chat | Enables/disables the slow chat. |
| Subscribers only chat | Enables/disables the subscribers only chat. |
| Stream marker | Places a stream marker. Only works while you're live! |

## Variables
| Variable | Description | Type |
| --- | --- | --- |
| USER_slow_chat | Indicates if the slow chat is enabled or disabled<br />Can be bound to the button state | Boolean |
| USER_followers_only_chat | Indicates if the followers only chat is enabled or disabled<br />Can be bound to the button state | Boolean |
| USER_subs_only_chat | Indicates if the subs only chat is enabled or disabled<br />Can be bound to the button state | Boolean |
| USER_emotes_only_chat | Indicates if the emotes only chat is enabled or disabled<br />Can be bound to the button state | Boolean |
| USER_viewers | The current viewer count of the live stream (Only while you're live!) | Number |
| USER_subscribers | The current subscribers count of the channel | Number |
| USER_followers | The current followers count of the channel | Number |

## Helping with the translation
All translation files are located under https://github.com/SuchByte/Macro-Deck-Twitch-Plugin/tree/master/Resources/Languages
### Adding/editing a translation file
1. Fork this GitHub repository
2. Add/edit the translation files
3. Create a pull request of the forked repository
### Note
Please use the ISO names for the file name and for the __Language__ node in the file. For __LanguageCode__ use the ISO-639-1 code. You can find more information here: https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes

### This is a plugin for [Macro Deck 2](https://github.com/SuchByte/Macro-Deck), it does NOT function as a standalone app
<img height="64px" src="https://macrodeck.org/images/macro_deck_2_official_plugin.png" />


## Third party licenses
This plugin uses some awesome 3rd party libraries:
- [TwitchLib (MIT license)](https://github.com/TwitchLib/TwitchLib)
- [Twitch logo in the icon (Creative-Commons)](https://commons.wikimedia.org/wiki/File:Twitch-icon-5.png)
