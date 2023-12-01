using System.Collections.ObjectModel;
using System.Linq;
using DeviationModule.Infrastructure;
using DeviationModule.Models;
using DeviationModule.ViewModels;

namespace DeviationModule.ViewModel
{
    internal class PositionViewModel : ViewModelBase
    {
        public ObservableCollection<Deviation> Deviations  { get; set; }
        public PositionViewModel()
        {
            using TestDbContext db = new();
            Deviations = new ObservableCollection<Deviation>(db.Positions.ToList());
            // получаем объекты из бд и выводим на консоль
            //Deviations = db.Positions.ToList();
        }
    }
}
