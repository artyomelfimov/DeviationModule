﻿using DeviationModule.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DeviationModule.Components
{
    internal class FilteredDataGrid : DataGrid, INotifyPropertyChanged
    {
        public static ICommand? OpenFilterCommand { get; set; }
        public Button button { get; private set; }
        public Popup popup { get; private set; }
        public ListBox FilteredListBox { get; private set; }
         

        public event PropertyChangedEventHandler? PropertyChanged;
        public FilteredDataGrid()
        {
            OpenFilterCommand = new RelayCommand(IsOpenFilterExecuted);
            Resources = new FilteredDataGridDictionary();
            button = new Button();
            FilteredListBox = new ListBox();
            popup = new Popup();
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if (!AutoGenerateColumns) {
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
            button = (Button)p;

            if (Items.Count == 0 || button == null) return;

            // navigate up to the current header and get column type
            var header = VisualTreeHelpers.FindAncestor<DataGridColumnHeader>(button);
            var columnType = header.Column.GetType();
            string? PropertyName = header.Column.SortMemberPath;
            // then down to the current popup
            popup = VisualTreeHelpers.FindChild<Popup>(header, "FilterPopup");
            popup.IsOpen = true;
            FilteredListBox = VisualTreeHelpers.FindChild<ListBox>(popup.Child, "FilteredListBox");
            var listboxitems = Items.Cast<Object>()
                .Select(x => x.GetType().GetProperty(PropertyName)?.GetValue(x, null))
                .Distinct()
                .Select(item => item)
                .ToList();
            FilteredListBox.ItemsSource = listboxitems;
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