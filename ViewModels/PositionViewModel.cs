using System.Collections.ObjectModel;
using DeviationModule.Models;

namespace DeviationModule.ViewModels
{
    internal class PositionViewModel : ViewModelBase, IViewModel
    {
        private Procedure? selectedProcedure;
        public Procedure? SelectedProcedure
        {
            get => selectedProcedure;
            set
            {
                selectedProcedure = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Deviation> Deviations  { get; set; }
        public PositionViewModel(ApplicationViewModel model)
        {
            SelectedProcedure = model.SelectedItem;
            Deviations = new ObservableCollection<Deviation>();
            Deviations = SelectedProcedure?.Deviations ?? new ObservableCollection<Deviation>();
        }

    }
}
