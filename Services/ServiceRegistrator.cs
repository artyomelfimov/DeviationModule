using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddSingleton<ProcedureManager>()
           .AddSingleton<ProcedureRepo>()
           .AddSingleton<LaunchRepo>()
           .AddSingleton<DeviationRepo>()
           .AddSingleton<UserDialogService>()
        ;
    }
}
