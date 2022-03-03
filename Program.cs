using System;
using System.IO;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Library.Services;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Splat;

namespace Library
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            // find views for viewmodels
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
            
            // read config file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            
            // put conf root to locator
            Locator.CurrentMutable.RegisterConstant(builder.Build(),
                typeof(IConfigurationRoot));

            // Register EF Context in Splat Locator
            Locator.CurrentMutable.RegisterConstant(
                new ApplicationContext(),
                typeof(ApplicationContext)
            );
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
        }
    }
}
