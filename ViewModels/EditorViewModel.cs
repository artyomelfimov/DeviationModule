using DeviationModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.ViewModels
{
    internal class EditorViewModel : ViewModelBase
    {
        ApplicationViewModel parentViewModel { get; set; }
        
        public EditorViewModel(ApplicationViewModel model) {
                parentViewModel = model;
                currentItem = model.SelectedItem;
            
        }
        private Procedure? currentItem;
        public Procedure? CurrentItem { get => currentItem; 
            set
            {
                currentItem = value;
                OnPropertyChanged();
            }
        }
    }
}
