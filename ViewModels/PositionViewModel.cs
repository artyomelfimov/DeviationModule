using System.Collections.ObjectModel;
using DeviationModule.Models;

namespace DeviationModule.ViewModel
{
    internal class PositionViewModel : ViewModelBase
    {
        public ObservableCollection<Deviation> Deviations  { get; set; }
        public PositionViewModel(ApplicationViewModel model)
        {
            Deviations = new ObservableCollection<Deviation>();
            Deviations = model.SelectedItem?.Deviations ?? new ObservableCollection<Deviation>();
           
        }
    }
}
