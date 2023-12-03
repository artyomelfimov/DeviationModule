﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DeviationModule.Infrastructure;
using DeviationModule.Models;
using DeviationModule.ViewModel;
using DeviationModule.Commands;
using Microsoft.EntityFrameworkCore;
using DeviationModule.Views;

namespace DeviationModule.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
    {
        public ICommand PositionCommand { get; set; }
        public ICommand LaunchCommand { get; set; }
        public ICommand EditorCommand { get; set; }

        private object? currentView;

        public object? CurrentView
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
            CurrentView = new();
            // получаем объекты из бд и выводим на консоль
            Procedures = db.Procedures.Include(u => u.Deviations).Include(u => u.Launches).ToList();
            PositionCommand = new RelayCommand(IsPositionCommandExecuted, CanCommandExecute);
            LaunchCommand = new RelayCommand(IsLaunchCommandExecuted, CanCommandExecute);
            EditorCommand = new RelayCommand(IsEditorCommandExecuted, CanCommandExecute);

        }
        
        private bool CanCommandExecute(object p) => SelectedItem != null;

        private void IsPositionCommandExecuted(object p) => CurrentView = new PositionViewModel(this);
        private void IsLaunchCommandExecuted(object p) => CurrentView = new PlaningViewModel(this);
        private void IsEditorCommandExecuted(object p) => CurrentView = new EditorViewModel(this);

    }
}
