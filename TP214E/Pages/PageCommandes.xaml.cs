using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        private List<Plat> _platsDisponibles;
        private readonly Commande _commandeEnCours;
        private DAL dal;

        public PageCommandes(DAL dal)
        {
            InitializeComponent();
            RafraichirPlatsDispo();
            this.dal = dal;
            _commandeEnCours = new Commande();
        }

        private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService is {CanGoBack: true})
            {
                NavigationService.GoBack();
            }
        }

        private void BtnAjouterPlat_OnClick(object sender, RoutedEventArgs e)
        {
            int index = lstBoxPlatsDispo.SelectedIndex;
            if (index != -1)
            {
                Plat platSelectionne = (Plat) lstBoxPlatsDispo.Items[index];
                PlatCommande platCommande = new PlatCommande(platSelectionne, 1);
                MettreAJourInventaire(platCommande, true);
                _commandeEnCours.AjouterPlat(platCommande);
                RafraichirCommande();
                RafraichirPlatsDispo();
            }
        }

        private void BtnRetirerPlat_OnClick(object sender, RoutedEventArgs e)
        {
            int index = lstBoxCommande.SelectedIndex;
            if (index != -1)
            {
                Plat platSelectionne = (Plat) lstBoxPlatsDispo.Items[index];
                PlatCommande platCommande = new PlatCommande(platSelectionne, 1);
                MettreAJourInventaire(platCommande, false);
                _commandeEnCours.RetirerPlat(platCommande);
                RafraichirCommande();
                RafraichirPlatsDispo();
            }
        }

        private void MettreAJourInventaire(PlatCommande platCommande, bool estAjout)
        {
            foreach (Ingredient ingredient in platCommande.Plat.Recette.Ingredients)
            {
                MettreAJourQuantiteAliment(platCommande.Quantite, ingredient, estAjout);
            }
        }

        private void MettreAJourQuantiteAliment(int quantitePlat, Ingredient ingredient, bool estAjout)
        {
            Aliment aliment =
                PageAccueil.Inventaire.LstAliments.Find(aliment => aliment.Id == ingredient.Aliment.Id);
            if (aliment != null)
            {
                if (estAjout)
                {
                    if (aliment.Quantite < ingredient.Quantite * quantitePlat)
                    {
                        MessageBox.Show("Vous n'avez pas suffisament d'ingrédients pour ajouter un plat de plus", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        aliment.Quantite -= ingredient.Quantite * quantitePlat;
                        dal.ModifierAliment(aliment.Id, aliment);
                    }
                }
                else
                {
                    aliment.Quantite += ingredient.Quantite * quantitePlat;
                    dal.ModifierAliment(aliment.Id, aliment);
                }
            }
        }

        private void RafraichirCommande()
        {
            lstBoxCommande.Items.Clear();
            foreach (PlatCommande plat in _commandeEnCours.PlatsCommandes)
            {
                lstBoxCommande.Items.Add(plat);
            }
        }

        private void RafraichirPlatsDispo()
        {
            _platsDisponibles = PageAccueil.Inventaire.ConsulterLesPLatsDisponibles();
            lstBoxPlatsDispo.ItemsSource = _platsDisponibles;
        }

        private void BtnReduireQtty_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (button.DataContext is PlatCommande platCommandeSelectionne)
            {
                platCommandeSelectionne.Quantite -= 1;
                MettreAJourInventaire(platCommandeSelectionne, false);
            }
        }

        private void BtnAugmenterQtty_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (button.DataContext is PlatCommande platCommandeSelectionne)
            {
                platCommandeSelectionne.Quantite += 1;
                MettreAJourInventaire(platCommandeSelectionne, true);
            }
        }
    }
}