# Subnetting-Calculator
Subnetting calculator for windows desktop

# About

## Info
This repository contains the code that is used by the windows desktop application Subnetting-Calculator

## Project Structure
```assets\ ``` -> Contains Media used by application

```docs\``` -> Contains project documentation

```lib\``` -> Contains the backend of the project which is a class library that contains code that is used to calculate various Subnetting information

```Subnetting Windows Desktop\``` -> Contains a WPF project using the Network.dll from lib to interface with the backend of the project

---
# Background

This application is my high school senior project for the Information Technology Shop.

I am writing this application because the set of tools that are contained in the application are used almost daily in our shop while we do the Cisco Networking Academy CCNA course


---
# Install

Use a prexisting binary in ```Subnetting Windows Desktop\bin\Release\```

or compile the project
---
# Compiling

First clone the repository
```git clone https://github.com/Wamadahama/Subnetting-Calculator.git```


## Requirements
  - Newtonsoft.json
  - MahApps.Metro
  - DocumentFormat.OpenXml
  - ClosedXML

## Compile steps
  - Open ```lib\Network\Network.sln``` and build Network.dll
  - Open ```Subnetting Windows Desktop\Subnetting Windows Desktop.sln```
  - Attach Network.dll to the project
  - Build and run

---
# Future
In the future I plan on adding some features
- Link Aggregation
- Wild card mask calculation
- Binary, Hex, and Decimal converter
- Ping tool
- Windows phone support 
---
