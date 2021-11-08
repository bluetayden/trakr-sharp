# trakr-sharp
 A C# desktop app for logging your time usage of programs

## Compiling
 Compiling requires Visual Studio and the '.NET desktop development' workload to be installed.  
 This repo makes use of WMI calls, meaning that you must run VS as an Admin if you wish to debug.  
 [VS Community 2019 was used for development]  

 Open `trakr-sharp.sln` (in Admin mode if required)  
 Select either `Debug` or `Release` as desired  
 Select `Build > Build Solution`  
 Press F5 to Debug or find the compiled program in `trakr-sharp/src/bin/Release`
