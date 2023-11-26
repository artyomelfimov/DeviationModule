using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DeviationModule.Infrastructure;
using DeviationModule.Models;
using DeviationModule.ViewModels;
using WpfApp1.Commands;

namespace WpfApp1.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
    {
        public ICommand OpenCommand { get; set; }
        public List<Procedure>? Procedures { get; set; }
        public Procedure? SelectedItem { get; set; }
        public ApplicationViewModel()
        {
            using TestDbContext db = new();

            // получаем объекты из бд и выводим на консоль
            Procedures = db.Procedures.ToList();
            OpenCommand = new RelayCommand(IsExitCommandExecuted, CanExitCommandExecute);
        }
        private bool CanExitCommandExecute(object p) => SelectedItem != null;
        private void IsExitCommandExecuted(object p)
        {
            PositionsWindow positionsWindow = new(this);
            positionsWindow.Show();
        }

    }
}
