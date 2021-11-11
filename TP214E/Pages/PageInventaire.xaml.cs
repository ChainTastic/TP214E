using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private DAL dal;

        public PageInventaire(DAL dal)
        {
            InitializeComponent();
            this.dal = dal;
            RafraichirInventaire();

        }


        private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void BtnSupprimer_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;

            if (button.DataContext is Aliment)
            {
                Aliment alimentSelectionne = (Aliment)button.DataContext;
                dal.RetirerAliment(alimentSelectionne);
                RafraichirInventaire();
            }
        }


        private void RafraichirInventaire()
        {
            lstBoxAliments.ItemsSource = dal.Aliments();
        }
    }
}