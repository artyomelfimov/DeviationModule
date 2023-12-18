using DeviationModule.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.ViewModels
{
    internal class ViewModelLocator
    {
        public ApplicationViewModel ApplicationViewModel => App.Host.Services.GetRequiredService<ApplicationViewModel>();
        public EditorViewModel EditorViewModel => App.Host.Services.GetRequiredService<EditorViewModel>();

        public PlaningViewModel PlaningViewModel => App.Host.Services.GetRequiredService<PlaningViewModel>();

        public PositionViewModel PositionViewModel => App.Host.Services.GetRequiredService<PositionViewModel>();

    }
}
