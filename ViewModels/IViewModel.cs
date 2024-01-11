using DeviationModule.Models;

namespace DeviationModule.ViewModels
{
    public interface IViewModel
    {
        public Procedure? SelectedProcedure { get; set; }
    }
}
