# Core Logging
This project is a set of abstractions over the dotnet core logging framework.

CoreLogging is available as a nuget package : 

https://www.nuget.org/packages/corelogging

It is welcome news that [logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1&tabs=aspnetcore2x) is a first class service in the dotnet core framework. This project provides some wrappers and extensions to make logging in dotnet core even easier to work with. There are three levels of abstraction.

## Testable Interfaces
While Microsoft provides an `ILogger` interface, the frequently called logging methods are all extension methods. This makes it difficult to determine if your logging message was called. Steve Smith has an excellent [article](https://ardalis.com/testing-logging-in-aspnet-core) laying out these difficulties.

This project follows his recommendation to use an adapter to wrap the framework `Logger`. The result is `ICoreLogger`. `ICoreLogger` is easy to mock and test and has the most used logging methods directly on the interface rather than using extension methods

There is also a generic `ICoreLogger<T>` which you should use on your constructor for dependency injection..

## Static Logger
While injecting an `ICoreLogger` is neat and testable, putting the interface on every constructor gets old fast. This project aims to make logging available everywhere. The first step in that direction is a static logger class called `ApplicationLogger`. Static classes can be tricky to test. but `ApplicationLogger` is safe to call at test time.  If  `Initialize()` is never called, the logging methods are no-op.

Call the `ApplictionLogger` like so:
``` C#
ApplicationLogger.LogWarning(this, "Danger, Will Robinson!");
```
To test logging with `ApplicationLogger`, mock an `ICoreLoggerFactory` that returns a mocked `ICoreLogger`. Call `ApplicationLogger.Initialize()` with your mocked factory and verify calls to the `ICoreLogger`.

## Extension Methods
This may be one step too far down the rabbit hole for some people. The goal is for logging to be ambiently available everywhere. To that end, there is a set of extension methods on `object` for the most common logging methods.  This means you can simply call:
``` C#
this.LogInformation("Bow ties are cool.");
```
The extension methods are in a separate namespace, so they will not pollute your intellisense unless you explicitly import them. The extension methods call `ApplicationLogger` internally, so they can be tested the same as above.

## Testing
See the [unit tests](https://github.com/alanstevens/CoreLogging/tree/master/src/CoreLoggingTests) for examples of the test approaches described above. 

## Startup
There is a `.AddCoreLogging()` extension method on `IServiceCollection` to configure Core Logging. Simply chain `.AddCoreLogging()` after `.AddMVC()` in `Startup.cs` like so:

``` C#
            services.AddMvc()
                .Services
                .AddCoreLogging();
```

---
There is a [sample](https://github.com/alanstevens/CoreLogging/blob/master/src/Sample/Controllers/HomeController.cs#L17) which demonstrates all three logging approaches.