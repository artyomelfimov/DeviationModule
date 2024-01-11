using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DeviationModule.Models;
using DeviationModule.Commands;
using Microsoft.Extensions.DependencyInjection;
using DeviationModule.Services;

namespace DeviationModule.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public ProcedureManager? ProcedureManager { get; set; }
        public ICommand PositionCommand { get; set; }
        public ICommand LaunchCommand { get; set; }
        public ICommand EditorCommand { get; set; }

        private IViewModel? currentView;

        public IViewModel? CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }
        public List<Procedure>? Procedures { get; set; }
        public List<Deviation>? Deviations { get; set; }
        public List<Launch>? Launches { get; set; }
        private Procedure? selectedItem;
        public Procedure? SelectedItem 
        {
            get => selectedItem;
            set { selectedItem = value;
                OnPropertyChanged();
                if (CurrentView != null)
                {
                    CurrentView.SelectedProcedure = selectedItem;
                }
            }
        }

        public ApplicationViewModel(ProcedureManager procedureManager)
        {
            ProcedureManager = procedureManager;
            //using TestDbContext db = new();
            // получаем объекты из бд и выводим на консоль
            //Procedures = db.Procedures.Include(u => u.Deviations).Include(u => u.Launches).ToList();
            Procedures = ProcedureManager?.Procedures.ToList();
            Deviations = ProcedureManager?.Deviations.ToList();
            Launches = ProcedureManager?.Launches.ToList();
            PositionCommand = new RelayCommand(IsPositionCommandExecuted, CanCommandExecute);
            LaunchCommand = new RelayCommand(IsLaunchCommandExecuted, CanCommandExecute);
            EditorCommand = new RelayCommand(IsEditorCommandExecuted, CanCommandExecute);


        }

        private bool CanCommandExecute(object p) => SelectedItem != null;

        private void IsPositionCommandExecuted(object p) => CurrentView = App.Host.Services.GetRequiredService<PositionViewModel>();
        private void IsLaunchCommandExecuted(object p) => CurrentView = App.Host.Services.GetRequiredService<PlaningViewModel>();
        private void IsEditorCommandExecuted(object p) => CurrentView = App.Host.Services.GetRequiredService<EditorViewModel>();

    }
}
