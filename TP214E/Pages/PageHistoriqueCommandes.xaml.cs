using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E.Pages
{
    /// <summary>
    /// Interaction logic for PageHistoriqueCommandes.xaml
    /// </summary>
    public partial class PageHistoriqueCommandes : Page
    {
        private DAL dal;

        public PageHistoriqueCommandes(DAL dal)
        {
            InitializeComponent();
            this.dal = dal;
            RafraichirHistorique();
        }

        private void RafraichirHistorique()
        {
            PageAccueil.Inventaire.LstCommandesTraite = dal.ObtenirCommandes();
            lstBoxCommandes.ItemsSource = PageAccueil.Inventaire.LstCommandesTraite;
        }

        private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}