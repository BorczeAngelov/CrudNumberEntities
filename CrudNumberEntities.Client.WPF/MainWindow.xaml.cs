using CrudNumberEntities.Client.WPF.ViewModel;
using System.Windows;

namespace CrudNumberEntities.Client.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }
    }
}
