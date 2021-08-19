# Core Logging
CoreLogging is a set of abstractions over the .NET Core logging framework. It aims to make logging more accessable and testable.

 [Logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1) is now a first class service in the .NET Core framework. This project provides some wrappers and extensions to make logging in dotnet core even easier to work with. There are three levels of abstraction:

## Testable Interfaces
Microsoft provides an `ILogger` interface, but the frequently called logging methods are extension methods. This makes it difficult to test that the correct logging method was called. Steve Smith has an [article](https://ardalis.com/testing-logging-in-aspnet-core) laying out these challenges.

 CoreLogging follows Steve's recommendation to use an adapter to wrap the framework `ILogger` interface. The result is `ICoreLogger`. `ICoreLogger` is easy to mock and test and has logging methods directly on the interface that mirror the `ILogger` extension methods

There is also a generic `ICoreLogger<T>` to use on a constructor for dependency injection.

## Static Logger
While `ICoreLogger` is clean and testable, putting the interface on every constructor gets old fast. CoreLogging aims to make logging easily accessable. The first step in that direction is a static logger class called `ApplicationLogger`. Static classes can be tricky to test, but `ApplicationLogger` is safe to call at test time.  If `Initialize()` is never called, the logging methods are no-op.

Call the `ApplictionLogger` like so:
``` C#
ApplicationLogger.LogWarning(this, "Danger, Will Robinson!");
```

## Extension Methods
 The goal of CoreLogging is to make logging easily available everywhere. To that end, there is a set of extension methods on `object` for the most common logging methods.  This means you can simply call:
``` C#
this.LogInformation("Bow ties are cool.");
```
The extension methods are in a separate namespace, so they will not pollute your intellisense unless you explicitly import them. The extension methods call `ApplicationLogger` internally, so they have no side effects at test time.

## Testing
See the [unit tests](https://github.com/alanstevens/CoreLogging/tree/master/src/CoreLoggingTests) for examples of how to use the CoreLogging components within your tests. 

## Startup
There is a `.AddCoreLogging()` extension method on `IServiceCollection` to configure Core Logging. Simply chain `.AddCoreLogging()` after the `.AddLogging()` framework extension method to setup CoreLogging in `Startup.cs` like so:

``` C#
            services
                .AddLogging();
                .AddCoreLogging();
```

---
There is a [sample](https://github.com/alanstevens/CoreLogging/blob/master/src/Sample/Controllers/HomeController.cs#L17) which demonstrates all three logging approaches.
