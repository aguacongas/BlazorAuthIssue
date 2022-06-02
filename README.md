# BlazorAuthIssue

This repo reproduce the issue : [[Blazor WASM] UserOptions not bound when published](https://github.com/dotnet/aspnetcore/issues/41998)

* Launch the server with : 
```bash
❯ dotnet run
Building...
info: Duende.IdentityServer.Startup[0]
      Starting Duende IdentityServer version 5.2.0+1c3f1fadb0fa7a4bea3f4a6f7028cbfcff3b9918 (.NET 7.0.0-preview.4.22229.4)
warn: Duende.IdentityServer[0]
      You do not have a valid license key for Duende IdentityServer. This is allowed for development and testing scenarios. If you are running in production you are required to have a licensed version. Please start a conversation with us: https://duendesoftware.com/contact
info: Duende.IdentityServer.Startup[0]
      Using explicitly configured authentication scheme Identity.Application for IdentityServer
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Projects\Tests\BlazorAuthIssue\Server
```

* Navigate to the */fetchdata* and login with **blazorissueuser** pwd: **Pass123$**

The page display the forecast. Everthing is OK.

* Publish the server with 
```bash
❯ dotnet publish -c Release
Microsoft (R) Build Engine version 17.3.0-preview-22226-04+f15ed2652 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\Projects\Tests\BlazorAuthIssue\Shared\BlazorAuthIssue.Shared.csproj (in 129 ms).
  Restored C:\Projects\Tests\BlazorAuthIssue\Client\BlazorAuthIssue.Client.csproj (in 437 ms).
  Restored C:\Projects\Tests\BlazorAuthIssue\Server\BlazorAuthIssue.Server.csproj (in 438 ms).
C:\Program Files\dotnet\sdk\7.0.100-preview.4.22252.9\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.RuntimeIdentifierInference.targets(216,5): message NETSDK1057:
You are using a preview version of .NET. See: https://aka.ms/dotnet-support-policy [C:\Projects\Tests\BlazorAuthIssue\Server\BlazorAuthIssue.Server.csproj]
C:\Program Files\dotnet\sdk\7.0.100-preview.4.22252.9\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.RuntimeIdentifierInference.targets(216,5): message NETSDK1057:
You are using a preview version of .NET. See: https://aka.ms/dotnet-support-policy [C:\Projects\Tests\BlazorAuthIssue\Shared\BlazorAuthIssue.Shared.csproj]
  BlazorAuthIssue.Shared -> C:\Projects\Tests\BlazorAuthIssue\Shared\bin\Release\net7.0\BlazorAuthIssue.Shared.dll
  BlazorAuthIssue.Client -> C:\Projects\Tests\BlazorAuthIssue\Client\bin\Release\net7.0\BlazorAuthIssue.Client.dll
  BlazorAuthIssue.Client (Blazor output) -> C:\Projects\Tests\BlazorAuthIssue\Client\bin\Release\net7.0\wwwroot
  BlazorAuthIssue.Server -> C:\Projects\Tests\BlazorAuthIssue\Server\bin\Release\net7.0\BlazorAuthIssue.Server.dll
  Optimizing assemblies for size may change the behavior of the app. Be sure to test after publishing. See: https://aka.ms/dotnet-illink
  Compressing Blazor WebAssembly publish artifacts. This may take a while...
  BlazorAuthIssue.Server -> C:\Projects\Tests\BlazorAuthIssue\Server\bin\Release\net7.0\publish\
```

* Launch the published in the publish folder server with 
```bash
❯ .\BlazorAuthIssue.Server.exe
info: Duende.IdentityServer.Startup[0]
      Starting Duende IdentityServer version 5.2.0+1c3f1fadb0fa7a4bea3f4a6f7028cbfcff3b9918 (.NET 7.0.0-preview.4.22229.4)
warn: Duende.IdentityServer[0]
      You do not have a valid license key for Duende IdentityServer. This is allowed for development and testing scenarios. If you are running in production you are required to have a licensed version. Please start a conversation with us: https://duendesoftware.com/contact
info: Duende.IdentityServer.Startup[0]
      Using explicitly configured authentication scheme Identity.Application for IdentityServer
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Projects\Tests\BlazorAuthIssue\Server\bin\Release\net7.0\publish
```

* Navigate to the */fetchdata" and login with **blazorissueuser** pwd: **Pass123$**

The page display : 

> You are not authorized to access this resource.
