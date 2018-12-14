# EasyDayz
## EasyDayz - Tool to manage DayZ SA Server

I wrote this tool, because BEC didn't work properly with DayZ SA (for me). To run EasyDayZ, you need the .NET Framework v4.6 installed. It was build with Microsoft Visual Studio Community 2017.

**EasyDayZ is in a very early stage and there will be bugs, use it on your own risk. I do not take any responsibility for any damaged caused by EasyDayZ!**

### Current features:
- view all to your server conneted players
- schedule tasks, commands and backups
- whitelisting by GUID
- banning by GUID
- a list of all players, that have been connected to your server
- execute battleye commands
- log textbox
- a watchdog to automatically restart your server after crash 

### Planned features:
- welcome message
- save logs
- native DayZ SA plugin for more features (control weather, time ...)

### Known bugs:
- connection loop if auto-reconnect is enabled and the admin password is wrong.

EasyDayZ uses the BattleNET (v1.3.4) Library.

EasyDayZ is not affiliated with or authorized by Bohemia Interactive.
