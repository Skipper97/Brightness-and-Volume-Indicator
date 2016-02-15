# Brightness and Volume Indicator for Windows 7

[![Build Status](https://travis-ci.org/Marox44/Brightness-and-Volume-Indicator.svg?branch=master)](https://travis-ci.org/Marox44/Brightness-and-Volume-Indicator)

Simple and lightweight, C# made indicator bar for screen brightness and volume change, similar to the one in Windows 8.

###### Some screenshots:

![screenshot1](http://i.imgur.com/vqde3Dj.png)
![screenshot1](http://i.imgur.com/NR3ITao.png)
![screenshot1](http://i.imgur.com/gtcY0a1.png)

![screenshot1](http://i.imgur.com/cQQNiPO.png)


## Download & Info

Download the latest release here: https://github.com/Marox44/Brightness-and-Volume-Indicator/releases

Currently designed for **Windows 7**


## Build

Solution originally created with *Visual Studio 2013*:

- `packages/MaroxLib` is **necessary**.
- uses **NAudio** library *(included as NuGet package, should be installed automatically)*
- `Setup` is currently a Windows Installer project. Don't change it unless you know what you're doing! **After building app project, remember to rebuild** `Setup`!

------

*** `Build solution` might not work currently. If so, just build app project and `Setup` project separately. ***


## The Great ToDo List

- Make an icon(s)
- Correct the `AssemblyInfo` file and information

#### Bugs
- On the first occurrence only, causes focus on the form

#### Features
- Currently window doesn't show up on maximum and minimum levels *(limitation of some kind; program is checking values periodically and shows when one of them changes)*

- **Installer**
	- Background bitmap image
	- Show license or sth
	- ~~Shortcut on desktop~~
	- ~~Add to autostart~~

- **Config Panel** - because program runs as a process *'in the background'*, a simple separated config window is needed for things like:
	- Update - check for and download ... !
	- Thread check interval
	- Autostart on/off
	- Volume/brightness features on/off
	- Change the colors :rainbow:
	- Change the size and position?


#### Tests & Checks
- ** General 'test' of app includes: **
	- correct install
	- any shortcuts working fine?
	- uninstall works?
	- is app added to startup, does it auto-starts with Windows?
	- volume and brightness changes
	- if they are no **memory leaks** (memory used should be no more than 40MB)
	- one-instance only
	- ** Systems to test: **
		- ~~Windows 7 64-bit~~
		- Windows 7 32-bit
		- Windows XP ... !
			- *currently I checked on XP SP3, app installs and runs, but no effect on audio and brightness change whatsoever*
- ** Check if source is able to build on different computer different VS ...** :exclamation:
- How it behaves without having .NET Framework? *(try to install and run)*


## Contribution

Feel free to send any remarks, suggestions about features, requests, questions and bug reports. ► [Submit an issue](https://github.com/Marox44/Brightness-and-Volume-Indicator/issues) ◄

You can also send any pull requests you want.

###### Thanks for any involvement and contribution! :wink:

> Contact me directly: [email](mailto:marek.lamasz@gmail.com)


## License

:copyright:
[MIT License](https://tldrlegal.com/license/mit-license)

- [NAudio](https://github.com/naudio/NAudio) library distributed under [Microsoft Public License (Ms-PL)](https://tldrlegal.com/license/microsoft-public-license-(ms-pl))
	- [http://naudio.codeplex.com/license](http://naudio.codeplex.com/license)
	- [http://naudio.codeplex.com/](http://naudio.codeplex.com/)
	- [https://www.nuget.org/packages/NAudio](https://www.nuget.org/packages/NAudio)


---

> Marek Łamasz ([Marox44](https://github.com/Marox44)) | 2015
