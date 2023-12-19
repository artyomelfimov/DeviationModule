using DeviationModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.ViewModels
{
    internal class EditorViewModel : ViewModelBase, IViewModel
    {
        private Procedure? selectedProcedure;
        public Procedure? SelectedProcedure 
        {
            get => selectedProcedure;
            set {
                selectedProcedure = value;
                OnPropertyChanged();
    }
}
ApplicationViewModel parentViewModel { get; set; }
        
        public EditorViewModel(ApplicationViewModel model) {
                parentViewModel = model;
                SelectedProcedure = model.SelectedItem;
            
        }
    }
}
