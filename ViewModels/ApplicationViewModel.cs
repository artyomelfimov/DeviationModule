using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DeviationModule.Infrastructure;
using DeviationModule.Models;
using DeviationModule.ViewModels;
using DeviationModule.Commands;

namespace DeviationModule.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
    {
        public ICommand OpenCommand { get; set; }
        private object? currentView;

        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }
        public List<Procedure>? Procedures { get; set; }
        private Procedure? selectedItem;
        public Procedure? SelectedItem 
        {
            get => selectedItem;
            set { selectedItem = value;
                OnPropertyChanged();
                }
        }

        public ApplicationViewModel()
        {
            using TestDbContext db = new();
            CurrentView = new PositionViewModel();
            // получаем объекты из бд и выводим на консоль
            Procedures = db.Procedures.ToList();
            OpenCommand = new RelayCommand(IsExitCommandExecuted, CanExitCommandExecute);
        }
        private bool CanExitCommandExecute(object p) => SelectedItem != null;
        private void IsExitCommandExecuted(object p)
        {
            PositionsWindow positionsWindow = new();
            positionsWindow.Show();
        }

    }
}
