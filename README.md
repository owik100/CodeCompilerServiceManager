# Code Compiler Service Manager
Desktop application for managing [Code Compiler Service](https://github.com/owik100/CoderCompilerWorkerService).
<br/>
Application enables full service management, monitoring and configuration.
<br/>
<br/>
<img src="https://owik100.github.io/Portfolio/images/Projects/Code%20Compiler%20Service%20Manager/Code%20Compiler%20Service%20Manager.gif" width="480" height="456">
- On status tab you can Run/Stop/Restart Service, check messages, remove files and go to input/output folder.
<img src="https://owik100.github.io/Portfolio/images/Projects/Code%20Compiler%20Service%20Manager/HomeControl.png" width="622" height="459">

- On manager settings tab you can choose to refresh service status automatically, refresh interval time and operation timeout.
<img src="https://owik100.github.io/Portfolio/images/Projects/Code%20Compiler%20Service%20Manager/ManagerSettings.png" width="622" height="459">

 - On service settings tab you can choose to save logs to Event log, txt file. Receiving messages from service, receiving "I am still alive" messages, chose free port or find it.
Choose number of threads to compilation, Internal buffer size, interval checking files in queue. Install or remove service.
<img src="https://owik100.github.io/Portfolio/images/Projects/Code%20Compiler%20Service%20Manager/ServiceSettings.png" width="622" height="459">

 - On compiling library settings tab you can set input/output folder and choose how files sholud be compiled (.dll or .exe).
<img src="https://owik100.github.io/Portfolio/images/Projects/Code%20Compiler%20Service%20Manager/LibrarySettings.png" width="622" height="459">

 ## Prerequisites
[.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) can be very helpful to compile project.
<br/>
Additionally, you need to add a reference to the project [Code Compiler Settings Models](https://github.com/owik100/CodeCompilerSettingsModels)
```
├── Code Compiler Service Manager   
└── Code Compiler Settings Models
```

 ## Installation
1. You can download app [here](https://github.com/owik100/CodeCompilerServiceManager/releases).
2. After the first launch, the application will ask for the path to the [service](https://github.com/owik100/CoderCompilerWorkerService).
3. You should also set the input and output paths on compiling library settings tab.
