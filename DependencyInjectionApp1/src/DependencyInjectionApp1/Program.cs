// 
// Copyright Notice:
// 
// Copyright 2017 Autodesk, Inc.  All rights reserved.
// 
// This computer source code and related instructions and 
// comments are the unpublished confidential and proprietary
// information of Autodesk, Inc. and are protected under 
// United States and foreign intellectual property laws.
// They may not be disclosed to, copied or used by any third
// party without the prior written consent of Autodesk, Inc.
// ---------------------------------------
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup our Dependency Injection
            // The first thing we do is configure the dependency injection container by creating a ServiceCollection, 
            // adding our dependencies, and finally building an IServiceProvider.This process is equivalent to the 
            // ConfigureServices method in an ASP.NET Core project, and is pretty much what happens behind the 
            // scenes. You can see we are using the IServiceCollection extension method to add the logging services 
            // to our application, and then registering our own services.The serviceProvider is our container we 
            // can use to resolve services in our application.
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IFooService, FooService>()
                .AddSingleton<IBarService, BarService>()
                .AddSingleton<IAnotherBarService, AnotherBarService>()
                .BuildServiceProvider();

            // Configure console logging
            // In the next step, we need to configure the logging infrastructure with a provider, so the results are output 
            // somewhere. We first fetch an instance of ILoggerFactory from our newly constructed serviceProvider, 
            // and add a console logger.
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            // The remainder of the program shows more dependency-injection in progress. 

            // We first fetch an ILogger<T> from the container
            var logger = serviceProvider.GetService<ILoggerFactory>()
                                        .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            // Do the actual work here
            // fetch an instance of IBarService.As per our registrations, the IBarService is an instance of BarService, 
            // which will have an instance of FooService injected in it.
            var bar = serviceProvider.GetService<IBarService>();
            var anotherBar = serviceProvider.GetService<IAnotherBarService>();
            bar.DoSomeRealWork();
            anotherBar.DoSomeRealWork();

            logger.LogDebug("All done!");
        }
    }
}
