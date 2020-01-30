﻿using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using System.IO;
using UnitystationLauncher.Models;

namespace UnitystationLauncher
{
    class Program
    {
        public static void Main(string[] args)
        {
            Config.Init();
            Directory.CreateDirectory(Config.InstallationsPath);
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .With(new X11PlatformOptions { UseGpu = true, UseEGL = true })
                .With(new AvaloniaNativePlatformOptions { UseGpu = true, UseDeferredRendering = false })
                .With(new MacOSPlatformOptions { ShowInDock = true })
                .With(new Win32PlatformOptions { UseDeferredRendering = false, AllowEglInitialization = true })
                .LogToDebug()
                .UseReactiveUI();
    }
}
