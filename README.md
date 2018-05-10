# Core Logging
This project is a set of abstractons over the dotnet core logging framework.

It is exciting that logging is a first class service in the dotnet core framework. Here you will find some wrappers and extensions to make logging in dotnet core even easier to work with. There are three levels of abstraction.

## Testable Interfaces
While Microsoft provides an `ILogger` interface, the frequently called logging methods are all extension methods. This makes it difficult to determine if your logging message was called. Steve Smith has an excellent [article](https://ardalis.com/testing-logging-in-aspnet-core) laying out these difficulties.

I have followed his recommendation to use an adapter to wrap the framework `Logger`. The result is `ICoreLogger` and `CoreLogger`. `ICoreLogger` is easy to mock and test and has the most used logging methods directly on the interface rather than using extension methods

There is also a generic `ICoreLogger<T>` which is what you should put on you constructor for dependency injection..

## Static Logger
While injecting an `ICoreLogger` is neat and testable, putting the interface on every constructor gets old fast. I believe Logging should be available everywhere. My first solution is a static logger class called `ApplicationLogger`. Static classes can be tricky to test. `ApplicationLogger` is safe to call at test time. Call the `ApplictionLogger` like so:

``` C#
ApplicationLogger.LogWarning(this, "Danger, Will Robinson!")
```

Internally it uses a set of delgates.  If  `Initialize` is never called, the logging methods are no-op. If you want to verify logging with `ApplicationLogger`, mock an `ICoreLoggerFactory` that returns a mocked `ICoreLogger`. Call `ApplicationLogger.Initialize()` with your mocked factory and verify calls to the `ICoreLogger`.

## Extension Methods
This may be one step too far down the rabbit hole for some people. Because I want logging to be ambiently available everywhere, I created a set of extension methods on `object` for the most common logging methods.  This means you can simply call `this.LogDebug("My message.)`. 

I put the extension methods in a seperate namespace so that they will not pollute your intellisense unless you explicitly import the namespace. The extension methods call `ApplicationLogger` internally, so they can be tested the same as above.

## Testing
See the [unit tests](https://github.com/alanstevens/CoreLogging/tree/master/src/CoreLoggingTests) for examples of the test approaches I describe above. Note that some tests fail intermittently when running all tests but succeed when run individually. I'd love a pull request that fixes this.

There is a [sample](https://github.com/alanstevens/CoreLogging/blob/master/src/Sample/Controllers/HomeController.cs#L17) which demonstrates all three logging approaches.

## Startup
There is a `.AddCoreLogging()` extension method on `ServiceCollection` to configure Core Logging. Simply chain `.AddCoreLogging()` after `.AddMVC()` in `Startup.cs` like so:

``` C#
            services.AddMvc()
                .Services
                .AddCoreLogging();
```