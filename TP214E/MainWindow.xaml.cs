using System.Windows;

namespace TP214E
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new PageAccueil());
        }
    }
}