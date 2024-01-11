using Microsoft.Extensions.DependencyInjection;

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
