using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DeviationModule.Models;
using WpfApp1.Commands;

namespace WpfApp1.ViewModel
{
    internal class PositionViewModel
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
