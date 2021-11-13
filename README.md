# trakr-sharp
 A C# desktop app for logging your time usage of programs.  
 Also provides global screenshotting and usage as a system tray app if required.  

## Technology
 * C#  
 * WinForms  
 * LiteDB  

 ## Libraries/Assets
  * [LiteDB](https://www.litedb.org/)  
  * [Json.NET](https://www.newtonsoft.com/json)  
  * [Google (Material UI Icons)](https://fonts.google.com/icons)  

## Installation
 Testing has only been performed with Windows 10.  
 The precompiled app can be found on the [latest releases page](https://github.com/bluetayden/trakr-sharp/releases/latest).   
 
  ## Usage
  * After downloading the latest release, extract all contents to a folder and run `trakr-sharp.exe`. Click on the 'Add' button to start tracking any processes you would like.  
  * If desired the settings page provides the option to minimize trakr to the app tray on close, as well as a flag to enable the global screenshot key (F12).  
  * Screenshots and the database used for storing times can be found in the `user_data` folder, located at the root where you launch the app.  
  * If you'd like to edit a particular record, select it in the main window and click on the 'Edit' button.  
  * There are some instances where an app may keep a background process running after you close it. In the event you would like to stop counting this time towards your total usage value, right click on the entry in the tracking list and select 'Stop Logging'. 

## Compiling
 Compiling requires Visual Studio and the ".NET desktop development" workload to be installed.  
 This repo makes use of WMI calls, meaning that you must run VS as an Admin if you wish to use the debugger.    
 [VS Community 2019 and .NET 472 were used for development]  

 1. Open `trakr-sharp.sln` (in Admin mode if required)  
 2. Select either `Debug` or `Release` as desired  
 3. Select `Build > Build Solution`  
 4. Press F5 to Debug or find the compiled program in `trakr-sharp/src/bin/Release`   

 ## Screenshots
  ![MainForm](https://i.imgur.com/5NY607r.png)  
  ![AddRecordsForm](https://i.imgur.com/1kvQ3s1.png)  
  ![EditRecordForm](https://i.imgur.com/r82Bdko.png)
