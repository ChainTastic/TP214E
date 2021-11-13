using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        private List<Plat> PlatsDisponibles;
        private Commande commandeEnCours;
        private DAL dal;
        public PageCommandes(DAL dal)
        {
            InitializeComponent();
            RafraichirPlatsDispo();
            this.dal = dal;
            commandeEnCours = new Commande();
        }

        private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void BtnAjouterPlat_OnClick(object sender, RoutedEventArgs e)
        {
            int index = lstBoxPlatsDispo.SelectedIndex;
            if (index != -1)
            {
                PlatCommande platSelectionne = (PlatCommande) lstBoxPlatsDispo.Items[index];
                foreach (Ingredient ingredient in platSelectionne.Plat.Recette.Ingredients)
                {
                    Aliment aliment =
                        PageAccueil.Inventaire.LstAliments.Find(aliment => aliment.Id == ingredient.Aliment.Id);
                    aliment.Quantite -= ingredient.Quantite;
                    PageAccueil.Inventaire.ModifierAliment(aliment);
                    commandeEnCours.AjouterPlat(platSelectionne);
                    dal.ModifierAliment(aliment.Id, aliment);
                }
                RafraichirCommande();
                RafraichirPlatsDispo();
            }
            
        }

        private void BtnRetirerPlat_OnClick(object sender, RoutedEventArgs e)
        {
            int index = lstBoxCommande.SelectedIndex;
            if (index != -1)
            {
                PlatCommande platSelectionne = (PlatCommande)lstBoxCommande.Items[index];
                foreach (Ingredient ingredient in platSelectionne.Plat.Recette.Ingredients)
                {
                    Aliment aliment =
                        PageAccueil.Inventaire.LstAliments.Find(aliment => aliment.Id == ingredient.Aliment.Id);
                    

                    aliment.Quantite += ingredient.Quantite;
                    PageAccueil.Inventaire.ModifierAliment(aliment);
                    commandeEnCours.RetirerPlat(platSelectionne);
                    dal.ModifierAliment(aliment.Id, aliment);
                }
                RafraichirCommande();
                RafraichirPlatsDispo();
            }
        }


        private void MettreAJourInventaire(Plat plat)
        {
            foreach (Ingredient ingredient in plat.Recette.Ingredients)
            {
                MettreAJourQuantiteAliment(ingredient);
            }
        }

        private void MettreAJourQuantiteAliment(Ingredient ingredient)
        {
            Aliment aliment =
                PageAccueil.Inventaire.LstAliments.Find(aliment => aliment.Id == ingredient.Aliment.Id);
            if (aliment != null)
            {
                aliment.Quantite -= ingredient.Quantite;
                PageAccueil.Inventaire.ModifierAliment(aliment);
                dal.ModifierAliment(aliment.Id,aliment);
            }
        }

        private void RafraichirCommande()
        {
            lstBoxCommande.Items.Clear();
            foreach (PlatCommande plat in commandeEnCours.PlatsCommandes)
            {
                lstBoxCommande.Items.Add(plat);
            }
        }

        private void RafraichirPlatsDispo()
        {
            PlatsDisponibles = PageAccueil.Inventaire.ConsulterLesPLatsDisponibles();
            lstBoxPlatsDispo.ItemsSource = PlatsDisponibles;
        }

        
    }
}