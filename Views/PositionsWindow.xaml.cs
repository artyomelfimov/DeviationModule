using System.Windows;
using DeviationModule.ViewModel;

namespace DeviationModule
{
    /// <summary>
    /// Логика взаимодействия для PositionsWindow.xaml
    /// </summary>
    public partial class PositionsWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParentProcedureId"></param>
        public PositionsWindow()
        {
            InitializeComponent();
            DataContext = new PositionViewModel();
        }
    }
}
