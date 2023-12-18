using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Navigation;
using DeviationModule.Commands;
using DeviationModule.Models;

namespace DeviationModule.ViewModels
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
