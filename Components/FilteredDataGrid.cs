using DeviationModule.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeviationModule.Components
{
    internal class FilteredDataGrid : DataGrid, INotifyPropertyChanged
    {
        public static ICommand? OpenFilterCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public FilteredDataGrid()
        {
            OpenFilterCommand = new RelayCommand(IsOpenFilterExecuted);
            Resources = new FilteredDataGridDictionary();

        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if (AutoGenerateColumns) {
                OnCustomColumnCreate();
            }
        }
        protected void OnCustomColumnCreate()
        {
            foreach (var item in Columns)
            {
                if (item != null && item.GetType() == typeof(DataGridTextColumn)) {
                    ((DataGridTextColumn)item).HeaderTemplate = (DataTemplate)FindResource("ColTemp");

                }

            }
        }
        public void IsOpenFilterExecuted(object p)
        {
        }
    }
    /// <summary>
    ///     ResourceDictionary
    /// </summary>
    public partial class FilteredDataGridDictionary
    {
        #region Public Constructors

        /// <summary>
        /// FilterDataGrid Dictionary
        /// </summary>
        public FilteredDataGridDictionary()
        {
            InitializeComponent();
        }

        #endregion Public Constructors
    }
}
