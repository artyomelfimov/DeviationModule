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
                OnPropertyChanged();
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
                if (RedDates != null)
                {
                    RedDates.Clear();
                    foreach (var item in Launches)
                    {
                        RedDates.Add(item.LaunchDate.Value.ToShortDateString());
                    }
                }
             
            }
        }
        
        public PlaningViewModel(ApplicationViewModel model)
        {
            SelectedProcedure = model.SelectedItem;
            Launches.ItemPropertyChanged += Launches_ItemPropertyChanged;
            RedDates = new ObservableCollection<string>();
            foreach (var item in Launches)
            {
                RedDates.Add(item.LaunchDate.Value.ToShortDateString());
            }

        }

        private void Launches_ItemPropertyChanged(object? sender, ItemPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LaunchDate")
            {

            }
        }
    }
}
