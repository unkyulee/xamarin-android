﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace App
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
        }
    }
}
