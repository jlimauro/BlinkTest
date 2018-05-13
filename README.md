# BlinkTest
Raspberry Pi with .NET Core 2.0 - Blinking LEDs

## Setting up Raspberry Pi (Pi 2 or Pi 3)

* Get lastest Raspiban Linunx distro from <a href="https://www.raspberrypi.org/downloads/raspbian/">RaspberryPi.org<a/>.
* Flash the distro to a SD Card - follow instructions <a href="https://www.raspberrypi.org/documentation/installation/installing-images/README.md">here</a>.
* Enable SSH on the Raspberry Pi

### Installing .NET Core 2.0 Runtime on Raspberry Pi

<b>Note:</b> At the current time the Raspberry Pi currently does not support the .NET Core 2.0 SDK, 
therefoe you will have to use another supported plateform in order to build this code.

#### Prerequisites:

```
sudo apt-get update
sudo apt-get install curl libunwind8 gettext apt-transport-https
```

#### Get lastest .NET Core Runtime for ARM32:
``` 
curl -sSL -o dotnet.tar.gz 
  https://dotnetcli.blob.core.windows.net/dotnet/Runtime/release/2.0.0/dotnet-runtime-latest-linux-arm.tar.gz
```
Extract the run time and create a symbolic link:
```
sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
```

## Building and Publishing the C# App

This application utilizes the C# <a href="https://github.com/unosquare/raspberryio">UnoSquare RaspberryIO</a> library. 
This will allow us to access the GPIO pins and to be able to blink the LEDs on the breadboard.

* In order to build and run the code on the Raspberry Pi the application must be published to the Linux ARM aritecture. We do that by doing the following:

```
dotnet publish -r linux-arm
```

### Transfer Files to Raspberry Pi

Now that the code has been built and published, we now need to copy the files to the Raspberry Pi. 
When doing so be sure to copy everything in the <b>publish</b> folder which should be inside the <b>linux-arm</b>
 folder.
 
 ### Running the code on the Raspberry Pi
 
 * Navigate to the location where you placed the files from the publish folder on the Raspberry Pi (ex. /pi/BlinkTest/)
 * Run the code by typing the following: ``` ./BlinkTest ```
 * The two LEDs on the breadboard should now be alternating and will each blink 10 times.
 
 My breadboard layout:
 
 <p align="left">
  <img width="200" height="300" src="https://github.com/jlimauro/BlinkTest/blob/master/IMG/LedBreadBoardLayout.JPG">
</p>
