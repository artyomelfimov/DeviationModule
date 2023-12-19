using DeviationModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.ViewModels
{
    public interface IViewModel
    {
        public Procedure? SelectedProcedure { get; set; }
    }
}
