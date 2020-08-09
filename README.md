# SNOW CHAT CLIENT APPLICATION

This Solution contains two project one in client which send and recieve message from the API and other is the rest API which will send data to the NAT Server 

#### It include powershell scrips where you need to replace ".exec" to ".exe" as gmail is not allowing to upload a file

## Pre Requisites

####  1.NATS.EXE.

To use the client you need to have a NATS Service running in the backgroud which you can download it from [here](https://nats.io/download/). Once you donwload the file just place it in the poject folder from where you can simply  run the powershell scripts which I have share or you can just click on NATS.exe_file which will make it up and running.

####  2.Visual Studio if you are a developer 

####  3.Windows OS for now :As we are using this application in.NET core we can run on any platform but now I have created to support it only forr windows we can make it self contained and run it in any platform.

## Compilation

To compile the project, click the solution file which will open the projects in VisualStudio  and change the configuration from Debug to Release mode of an application and build both the projects.

## Run

There are two way to run the application.

  #### 1. Through visual Studio.

To Run the application make both the projects as a start up project and run it in the release mode, you can create as many instance of the client application to start a chat, initially we will try to create only one instance which will just talk to itself.

To start a chat you need to enter the username otherwise you cannot recieve the message from the subject which you have subscribed.

  #### 2. Through powershell script.

Run powershell script "start-demo.ps1" which will create a 2 instance of the client and one instance of the API which.

And to start a chat between these client you need to enter the username.

To quit the application user need to enter quit  which will exit the client.

## License

Please contact [rohan.bingi@gmail.com]