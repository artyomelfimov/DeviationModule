using DeviationModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.ViewModel
{
    class PlaningViewModel : ViewModelBase
    {
        public ObservableCollection<Launch> Launches { get; set; }
        public PlaningViewModel(ApplicationViewModel model)
        {
            Launches = new ObservableCollection<Launch>();
            Launches = model.SelectedItem?.Launches ?? new ObservableCollection<Launch>();

        }
    }
}
