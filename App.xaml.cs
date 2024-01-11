using DeviationModule.Services;
using DeviationModule.ViewModels;
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
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }
        public static void ConfigureServices(HostBuilderContext context,IServiceCollection services)
        {
            services.AddSingleton<ApplicationViewModel>();
            services.AddTransient<PlaningViewModel>();
            services.AddTransient<PositionViewModel>();
            services.AddTransient<EditorViewModel>();
            services.AddSingleton<ProcedureManager>();
            services.AddSingleton<ProcedureRepo>();
            services.AddSingleton<LaunchRepo>();
            services.AddSingleton<DeviationRepo>();
        }
    }

}
