using System;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private DAL dal;

        public PageAccueil()
        {
            InitializeComponent();
            dal = new DAL();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(dal);

            this.NavigationService.Navigate(frmInventaire);
        }

        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));
        }
    }
}