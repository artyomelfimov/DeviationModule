using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule
{
    public static class Program
    {
        [STAThread]
        public static void Main() 
        {
            App app = new();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
          .CreateDefaultBuilder(args)
          .ConfigureServices(App.ConfigureServices);
    }
}
