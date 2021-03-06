﻿// 
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
namespace DependencyInjectionApp1
{
    public class BarService : IBarService
    {
        private readonly IFooService _fooService;

        public BarService(IFooService fooService)
        {
            _fooService = fooService;
        }

        public void DoSomeRealWork()
        {
            for (int i = 0; i < 10; i++)
            {
                _fooService.DoThing(i);
            }
        }
    }
}
