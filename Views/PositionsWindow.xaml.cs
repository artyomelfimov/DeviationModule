using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1
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
        public PositionsWindow(ApplicationViewModel ParentViewModel)
        {
            InitializeComponent();
            DataContext = new PositionViewModel(ParentViewModel);
        }
    }
}
