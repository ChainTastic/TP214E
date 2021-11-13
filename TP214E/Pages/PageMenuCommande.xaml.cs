using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;
using TP214E.Pages;

namespace TP214E
{
    /// <summary>
    /// Interaction logic for PageMenuCommande.xaml
    /// </summary>
    public partial class PageMenuCommande : Page
    {
        private DAL dal;

        public PageMenuCommande(DAL dal)
        {
            InitializeComponent();
            this.dal = dal;
        }

        private void btnHistoriqueCommandes_Click(object sender, RoutedEventArgs e)
        {
            PageHistoriqueCommandes pageHistoriqueCommandes = new PageHistoriqueCommandes(dal);

            NavigationService navigationService = NavigationService;
            navigationService?.Navigate(pageHistoriqueCommandes);
        }

        private void btnCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            PageCommandes pageCommandes = new PageCommandes(dal);

            NavigationService navigationService = NavigationService;
            navigationService?.Navigate(pageCommandes);
        }
    }
}