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
using Microsoft.Extensions.Logging;

namespace DependencyInjectionApp1
{
    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;

        public FooService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooService>();
        }

        public void DoThing(int number)
        {
            _logger.LogInformation($"Doing the thing {number}");
        }
    }
}
