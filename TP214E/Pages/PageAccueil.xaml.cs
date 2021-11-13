using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private DAL dal;
        public static Inventaire Inventaire;


        public PageAccueil()
        {
            InitializeComponent();
            dal = new DAL();
            Inventaire = new Inventaire();
            Inventaire.LstAliments = dal.Aliments();
            Inventaire.LstRecettes = dal.ObtenirRecettes();
            Inventaire.LstPlats = dal.ObtenirPlats();
            Inventaire.LstCommandesTraite = dal.ObtenirCommandes();
        }


        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(dal);

            NavigationService navigationService = this.NavigationService;
            navigationService?.Navigate(frmInventaire);
        }

        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = this.NavigationService;
            navigationService?.Navigate(new PageCommandes(dal));
        }
    }
}