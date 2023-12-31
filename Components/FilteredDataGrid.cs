using DeviationModule.Commands;
using DeviationModule.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace DeviationModule.Components
{
    internal class FilteredDataGrid : DataGrid, INotifyPropertyChanged
    {
        public static ICommand? OpenFilterCommand { get; set; }
        public Dictionary<string,Predicate<object>>? Criteria { get; set; }
        public ICollectionView? FilteredDataGridView { get; set; }

        public Button Button { get; private set; }
        public Popup Popup { get; private set; }
        public ListBox FilteredListBox { get; private set; }
         
        public List<FilterListElement> FilterItems {  get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public FilteredDataGrid()
        {
            OpenFilterCommand = new RelayCommand(IsOpenFilterExecuted);
            Resources = new FilteredDataGridDictionary();
            Button = new Button();
            FilteredListBox = new ListBox();
            Popup = new Popup();
            FilterItems = new();
            
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if (!AutoGenerateColumns) {
                OnCustomColumnCreate();
            }
            Criteria = new Dictionary<string, Predicate<object>>();
            FilteredDataGridView = CollectionViewSource.GetDefaultView(ItemsSource);
            FilteredDataGridView.Filter = Filter;
        }
        protected void OnCustomColumnCreate()
        {
            foreach (var item in Columns)
            {
                if (item != null && item.GetType() == typeof(FilteredDataGridTextColumn)) {
                    ((FilteredDataGridTextColumn)item).HeaderTemplate = (DataTemplate)FindResource("ColTemp");

                }

            }
        }
        public void IsOpenFilterExecuted(object p)
        {
            Button = (Button)p;

            if (Items.Count == 0 || Button == null) return;

            // navigate up to the current header and get column type
            var header = VisualTreeHelpers.FindAncestor<DataGridColumnHeader>(Button);
            var columnType = header.Column.GetType();
            string? PropertyName = header.Column.SortMemberPath;
            // then down to the current popup
            Popup = VisualTreeHelpers.FindChild<Popup>(header, "FilterPopup");
            Popup.IsOpen = true;
            FilteredListBox = VisualTreeHelpers.FindChild<ListBox>(Popup.Child, "FilteredListBox");
            var columnitems = Items.Cast<Object>()
                .Select(x => x.GetType().GetProperty(PropertyName)?.GetValue(x, null))
                .Distinct()
                .Select(item => item)
                .ToList();
            foreach (var item in columnitems)
            {
                FilterItems.Add(new FilterListElement { IsChecked = true, Element = item.ToString() });
            }
            FilteredListBox.ItemsSource = FilterItems;
        }
        private bool Filter(object o)
        {
            return Criteria.Values.Aggregate(true,
                   (prevValue, predicate) => prevValue && predicate(o));
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
    public class FilterListElement
    {
        public bool IsChecked { get; set; }

        public string? Element { get; set; }
    }
}
