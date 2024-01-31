using DeviationModule.DAL.Context;
using DeviationModule.Infrastructure;
using DeviationModule.Services;
using DeviationModule.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DeviationModule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost? _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Host.Services;
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DBInitializer>().InitializeAsync().Wait();

            base.OnStartup(e);
            await host.StartAsync();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .AddDatabase(host.Configuration.GetSection("Database"))
           .AddServices()
           .AddViewModels()
        ;
        //public static void ConfigureServices(HostBuilderContext context,IServiceCollection services)
        //{
        //    services.AddSingleton<ApplicationViewModel>();
        //    services.AddTransient<PlaningViewModel>();
        //    services.AddTransient<PositionViewModel>();
        //    services.AddTransient<EditorViewModel>();
        //    services.AddSingleton<ProcedureManager>();
        //    services.AddSingleton<ProcedureRepo>();
        //    services.AddSingleton<LaunchRepo>();
        //    services.AddSingleton<DeviationRepo>();
        //    services.AddSingleton<UserDialogService>();
        //    AddDatabase(services);
        //}
    }

}
