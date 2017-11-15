Generated using dotnet core's cli for a lambda.AspNetCoreWebAPI, then adjusted to remove unneeeded code to  have a barebones setup

Setup
===

Generate a zip wwith the code for deploy
* `dotnet lambda package`

This will generate a zip, go upload that to lambda, our sample handler is `AspNetCoreWebAPI::AspNetCoreWebAPI.LambdaEntryPoint::FunctionHandlerAsync`

In order to get the full value out of this project, We need to setup the following in API Gateway:
* A greedy proxy. 
* Create a method with an `ANY` method.
* Then for the integration response we want to use a lambda

Resources
====
* https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.AspNetCoreServer/README.md
