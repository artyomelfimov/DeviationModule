using DeviationModule.Models;

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

        public ApplicationViewModel ParentViewModel { get; set; }
        
        public EditorViewModel(ApplicationViewModel model) {
                ParentViewModel = model;
                SelectedProcedure = model.SelectedItem;
            
        }
    }
}
