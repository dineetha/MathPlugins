# MathPlugins
## A simple plug-in system example for Windows desktop applications written in C#

This repository contains code for example plug-in system that loads DLL assemblies at runtime. Without changing source code of the program new plug-ins can be added. This code is published for educational purposes for those who are learning C#, .NET technologies and specially trying to implement a plug-in architecture.
This program does mathematical operations on two numbers. There are 4 example assemblies to add, subtract, multiply and divide two numbers. Build MathPlugins program and four assemblies. Copy one or more assemblies to MathPlugins debug folder. Then run MathPlugins program. The program will load plug-ins and create buttons with methods for each plug-in.
This program uses [Assembly](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly?view=netframework-4.6 "Learn") class of [Reflection namespace](https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection "Learn") and [Activator](https://docs.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=netframework-4.6 "Learn") class.
