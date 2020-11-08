# FragmentJamella
A character editor for .hack//fragment

### Features:  
Change the class and model of your currently loaded character
* Does not change stats or equipped items other than weapons

### Usage:  
**Needs to be run with elevated privileges**  
Load the character you want to edit (Works online and offline. Can be done on The World login screen as well)  
Select the class/model/color/height/width that you want to change to  
Click "Change Class!" button  
Save your character immediately (It is highly recommended that you *do not* play before saving and reloading. May cause soft locks or crashes, especially online)  

##Linux Support
for the linux version the program needs root privileges.
if you are running x86 machine , I would suggest to build the application on the x86 machine as the binaries in the release were not tested on x86

##Linux Build
To build on Linux, please install git,cmake,make and mono-complete 
clone the repo and run the linuxBuild.sh script 

### Credits:  
Process attaching and memory editing copied from https://github.com/Zero1UP/fragment-shortcut-overlay
Linux Memory Access Provided by Zackmon https://github.com/Zackmon/SimpleLinuxMemoryAccess
