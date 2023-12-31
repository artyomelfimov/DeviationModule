using DeviationModule.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DeviationModule.Components
{
    internal class FilteredDataGridTextColumn : DataGridTextColumn
    {

        public FilteredDataGridTextColumn() : base() {
            Debug.WriteLine("Shit");
        }
    }
}
