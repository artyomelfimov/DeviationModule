using DeviationModule.Commands;
using DeviationModule.Components;
using DeviationModule.Models;
using DeviationModule.Services;
using DeviationModule.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Windows.Networking;

namespace DeviationModule.ViewModels
{
    class PlaningViewModel : ViewModelBase , IViewModel
    {
        private UserDialogService UserDialogService;
        private ProcedureManager ProcedureManager;
         
        private Procedure? selectedProcedure;
        private Launch? selectedLaunch;
        public ICommand EditLaunchCommand {  get; set; }
        public Procedure? SelectedProcedure
        {
            get => selectedProcedure;
            set
            {
                selectedProcedure = value;
                OnPropertyChanged();
                Launches = selectedProcedure?.Launches ?? [];
            }
        }
        public Launch? SelectedLaunch
        {
            get => selectedLaunch;
            set
            {
                selectedLaunch = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string>? redDates;
        public ObservableCollection<string>? RedDates
        {
            get
            {
                return redDates;
            }
            set
            {
                redDates = value;
                OnPropertyChanged();
            }
        }
        private FullyObservableCollection<Launch>? launches;

        public FullyObservableCollection<Launch>? Launches
        {
            get=> launches;
            set
            {
                
                launches = value;
                OnPropertyChanged();
                if (RedDates != null)
                {
                    RedDates.Clear();
                    foreach (var item in Launches)
                    {
                        RedDates.Add(item.LaunchDate.Value.ToShortDateString());
                    }
                }
             
            }
        }
        
        public PlaningViewModel(ApplicationViewModel model,ProcedureManager _ProcedureManager,UserDialogService _UserDialogService)
        {
            SelectedProcedure = model.SelectedItem;
            Launches.ItemPropertyChanged += Launches_ItemPropertyChanged;
            RedDates = new ObservableCollection<string>();
            foreach (var item in Launches)
            {
                RedDates.Add(item.LaunchDate.Value.ToShortDateString());
            }
            UserDialogService = _UserDialogService;
            ProcedureManager = _ProcedureManager;
            EditLaunchCommand = new RelayCommand(IsEditLaunchCommandExecuted,CanExecuteEditLaunchCommand);
        }

        private void Launches_ItemPropertyChanged(object? sender, ItemPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LaunchDate")
            {

            }
        }
        private bool CanExecuteEditLaunchCommand(object item) => item != null & item is Launch;

        private void IsEditLaunchCommandExecuted(object p)
        {
            var launch = (Launch) p;
            if (launch != null)
            {
            if (UserDialogService.Edit(p))
                ProcedureManager.Update((Launch)p);

                    MessageBox.Show("Пользователь выполнил редактирование");
            }
            else
                MessageBox.Show("Пользователь отказался");

        }
    }
}
