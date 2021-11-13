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

        private void LstBoxCommandes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstBoxCommandes.SelectedIndex;
            if (index != -1)
            {
                Commande commandeSelectionne = (Commande) lstBoxCommandes.Items[index];
                RafraichirArticles(commandeSelectionne);
            }
        }

        private void RafraichirArticles(Commande commandeSelectionne)
        {
            lstBoxPlats.Items.Clear();
            foreach (PlatCommande platCommande in commandeSelectionne.PlatsCommandes)
            {
                lstBoxPlats.Items.Add(platCommande);
            }
        }
    }
}