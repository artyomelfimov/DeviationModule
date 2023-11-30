using System.Collections.ObjectModel;
using System.Linq;
using DeviationModule.Infrastructure;
using DeviationModule.Models;
using DeviationModule.ViewModels;

namespace WpfApp1.ViewModel
{
    internal class PositionViewModel : ViewModelBase
    {
        public ObservableCollection<Deviation> Deviations  { get; set; }
        public PositionViewModel(ApplicationViewModel ParentViewModel)
        {
            using TestDbContext db = new();
            Deviations = new ObservableCollection<Deviation>(db.Positions.ToList().Where(x => x.ProcId == ParentViewModel.SelectedItem?.Id));
            // получаем объекты из бд и выводим на консоль
            //Deviations = db.Positions.ToList();
        }
    }
}
