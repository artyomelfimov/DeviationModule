using DeviationModule.Components;
using DeviationModule.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media;

namespace DeviationModule.ViewModels
{
    class PlaningViewModel : ViewModelBase , IViewModel
    {
        private Procedure? selectedProcedure;
        public Procedure? SelectedProcedure
        {
            get => selectedProcedure;
            set
            {
                selectedProcedure = value;
                OnPropertyChanged();
                Launches = selectedProcedure?.Launches ?? [];
            }
        }
        private FullyObservableCollection<Launch>? launches;

        public FullyObservableCollection<Launch>? Launches
        {
            get=> launches;
            set
            {
                launches = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string>? redDates;
        public ObservableCollection<string>? RedDates
        {
            get
            {
                return redDates;
            }
            set
            {
                redDates = value;
                OnPropertyChanged(nameof(RedDates));
            }
        }
        public PlaningViewModel(ApplicationViewModel model)
        {
            SelectedProcedure = model.SelectedItem;
            Launches.ItemPropertyChanged += Launches_ItemPropertyChanged;

        }

        private void Launches_ItemPropertyChanged(object? sender, ItemPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Period")
            {

            }
        }
    }
}
