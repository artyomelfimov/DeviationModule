using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeviationModule.Views
{
    /// <summary>
    /// Логика взаимодействия для LaunchEditWindowView.xaml
    /// </summary>
    public partial class LaunchEditWindowView : Window
    {
        public static DependencyProperty OwnerProperty = DependencyProperty.Register(
            nameof(Owner),
            typeof(string),
            typeof(LaunchEditWindowView),
            new PropertyMetadata(null)
            );
        public new string Owner { get => (string)GetValue(OwnerProperty);set => SetValue(OwnerProperty,value); }
        
        public static DependencyProperty PeriodProperty = DependencyProperty.Register(
            nameof(Period),
            typeof(string),
            typeof(LaunchEditWindowView),
            new PropertyMetadata(null)
            );
        public string Period { get => (string)GetValue(PeriodProperty); set => SetValue(PeriodProperty, value); }

        public static DependencyProperty StartDateProperty = DependencyProperty.Register(
            nameof(Owner),
            typeof(DateTime),
            typeof(LaunchEditWindowView),
            new PropertyMetadata(null)
            );
        public DateTime StartDate { get => (DateTime)GetValue(StartDateProperty); set => SetValue(StartDateProperty, value); }
        
        public static DependencyProperty StartTimeProperty = DependencyProperty.Register(
            nameof(StartTime),
            typeof(DateTime),
            typeof(LaunchEditWindowView),
            new PropertyMetadata(null)
            );
        public DateTime StartTime { get => (DateTime)GetValue(StartTimeProperty); set => SetValue(StartTimeProperty, value); }

        public LaunchEditWindowView()
        {
            InitializeComponent();
        }
    }
}
