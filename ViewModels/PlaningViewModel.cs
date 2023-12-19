using DeviationModule.Models;
using System.Collections.ObjectModel;

namespace DeviationModule.ViewModels
{
    class PlaningViewModel : ViewModelBase , IViewModel
    {
        private Procedure? selectedProcedure;
        private ObservableCollection<Launch>? launches;
        public Procedure? SelectedProcedure
        {
            get => selectedProcedure;
            set
            {
                selectedProcedure = value;
                OnPropertyChanged();
                launches = selectedProcedure?.Launches ?? new ObservableCollection<Launch>();
            }
        }

        public ObservableCollection<Launch>? Launches
        {
            get=> launches;
            set
            {
                launches = value;
                OnPropertyChanged(nameof(launches));
            }
        }
        public PlaningViewModel(ApplicationViewModel model)
        {
            SelectedProcedure = model.SelectedItem;

        }
    }
}
