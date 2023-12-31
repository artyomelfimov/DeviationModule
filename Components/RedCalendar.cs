using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace DeviationModule.Components
{
    public class RedCalendar : System.Windows.Controls.Calendar

    {
        public static DependencyProperty HighlightedVisibilityProperty = DependencyProperty.Register
            (
                "HighlightedVisibility",
                typeof(System.Windows.Visibility),
                typeof(RedCalendar),
                new PropertyMetadata()
            );
        public static DependencyProperty RedDatesCollectionProperty = DependencyProperty.Register
            (
                "RedDatesCollection",
                typeof(ObservableCollection<string>),
                typeof(RedCalendar),
                new PropertyMetadata());

        public System.Windows.Visibility HighlightedVisibility
        {
            get { return (System.Windows.Visibility)GetValue(HighlightedVisibilityProperty); }
            set { SetValue(HighlightedVisibilityProperty, value); }
        }
        public ObservableCollection<string> RedDatesCollection
        {
            get { return (ObservableCollection<string>)GetValue(RedDatesCollectionProperty); }
            set
            {
                SetValue(RedDatesCollectionProperty, value);
            }
        }

        public RedCalendar()
        {
            this.Resources = new ResourceDictionary();

            RedDatesCollection = new ObservableCollection<string>();
        }

        public void ValueChanged(object sender, EventArgs e)
        {
            this.CalendarDayButtonStyle = null;
            this.CalendarDayButtonStyle = (Style)TryFindResource("CustomCalendarDayButtonStyle");
        }

    }
    public class RedDatesConverter : IMultiValueConverter
    {
        public object? Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var RedDate = values[0].ToString();
            var RedCal = (RedCalendar)values[1];
            if (RedCal.RedDatesCollection != null && RedCal.RedDatesCollection.Contains(RedDate))
            {
                return values[0];
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
    public partial class DictionaryForCalendar
    {
        public DictionaryForCalendar()
        {
            InitializeComponent();
        }
    }
}
