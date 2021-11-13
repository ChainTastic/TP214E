using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        private List<Plat> _platsDisponibles;
        private Commande _commandeEnCours;
        private DAL dal;

        public PageCommandes(DAL dal)
        {
            this.dal = dal;
            _commandeEnCours = new Commande();
            DataContext = _commandeEnCours;
            InitializeComponent();
            PageAccueil.Inventaire.LstPlats = dal.ObtenirPlats();
            RafraichirPlatsDispo();
        }

        private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService is {CanGoBack: true})
            {
                if (_commandeEnCours.PlatsCommandes.Count > 0 && DemanderConfirmation("Si vous quitter cette page, la commande en cours sera annulé."))
                {
                    ReinitialiserCommande();
                    NavigationService.GoBack();
                }
            }
        }

        private bool DemanderConfirmation(string message)
        {
            return MessageBox.Show(message, "Attention", MessageBoxButton.OKCancel, MessageBoxImage.Error) == MessageBoxResult.OK;
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
                RafraichirPlatsDispo();
                RafraichirCommande();
            }
        }

        private void BtnAnnulerCommande_OnClick(object sender, RoutedEventArgs e)
        {
            if (DemanderConfirmation("Êtes-vous certain de vouloir annuler la commande ?"))
            {
                ReinitialiserCommande();
                RafraichirPlatsDispo();
            }
        }

        private void BtnConfirmerCommande_OnClick(object sender, RoutedEventArgs e)
        {
            if (_commandeEnCours.PlatsCommandes.Count > 0)
            {
                PageAccueil.Inventaire.AjouterCommande(_commandeEnCours);
                dal.AjouterCommande(_commandeEnCours);
                ReinitialiserCommande();
                RafraichirPlatsDispo();
            }
            else
            {
                MessageBox.Show("Vous devez ajouter des plats à votre commande.", "Attention", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void MettreAJourInventaire(PlatCommande platCommande, bool estAjout)
        {
            if (platCommande.Plat.Recette.VerifierDisponibilite())
            {
                foreach (Ingredient ingredient in platCommande.Plat.Recette.Ingredients)
                {
                    MettreAJourQuantiteAliment(ingredient, estAjout);
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas suffisament d'ingrédients pour ajouter un plat de plus", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MettreAJourQuantiteAliment(Ingredient ingredient, bool estAjout)
        {
            Aliment aliment =
                PageAccueil.Inventaire.LstAliments.Find(aliment => aliment.Id == ingredient.Aliment.Id);
            if (aliment != null)
            {
                if (estAjout)
                {
                    if (aliment.Quantite >= ingredient.Quantite)
                    {
                        aliment.Quantite -= ingredient.Quantite;
                        dal.ModifierAliment(aliment.Id, aliment);
                    }
                }
                else
                {
                    aliment.Quantite += ingredient.Quantite;
                    dal.ModifierAliment(aliment.Id, aliment);
                }
            }
        }

        private void RafraichirCommande()
        {
            lstBoxCommande.Items.Clear();
            grilleCommande.DataContext = _commandeEnCours;
            foreach (PlatCommande plat in _commandeEnCours.PlatsCommandes)
            {
                lstBoxCommande.Items.Add(plat);
            }

            FaireCalculCommande();
            MettreAJourLesPrix();
        }

        private void MettreAJourLesPrix()
        {
            txtSousTotalCommande.Text = $"{_commandeEnCours.SousTotal:c}";
            txtTPSCommande.Text = $"{_commandeEnCours.TPS:c}";
            txtTVQCommande.Text = $"{_commandeEnCours.TVQ:c}";
            txtTotalCommande.Text = $"{_commandeEnCours.Total:c}";
        }

        private void FaireCalculCommande()
        {
            _commandeEnCours.SousTotal = _commandeEnCours.CalculerSousTotal();
            _commandeEnCours.TPS = _commandeEnCours.CalculerTPS();
            _commandeEnCours.TVQ = _commandeEnCours.CalculerTVQ();
            _commandeEnCours.Total = _commandeEnCours.CalculerTotal();
        }

        private void RafraichirPlatsDispo()
        {
            if (PageAccueil.Inventaire != null)
            {
                PageAccueil.Inventaire.LstPlats = dal.ObtenirPlats();
                _platsDisponibles = PageAccueil.Inventaire.ConsulterLesPLatsDisponibles();
            }
            else
            {
                _platsDisponibles = PageAccueil.Inventaire.ConsulterLesPLatsDisponibles();
            }

            lstBoxPlatsDispo.ItemsSource = _platsDisponibles;
        }

        private void BtnReduireQtty_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (button.DataContext is PlatCommande platCommandeSelectionne)
            {
                if (platCommandeSelectionne.Quantite <= 1)
                {
                    _commandeEnCours.PlatsCommandes.Remove(platCommandeSelectionne);
                }

                platCommandeSelectionne.Quantite -= 1;
                MettreAJourInventaire(platCommandeSelectionne, false);
                RafraichirPlatsDispo();
                RafraichirCommande();
            }
        }

        private void BtnAugmenterQtty_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (button.DataContext is PlatCommande platCommandeSelectionne)
            {
                if (platCommandeSelectionne.Plat.Recette.VerifierDisponibilite())
                {
                    platCommandeSelectionne.Quantite += 1;
                    MettreAJourInventaire(platCommandeSelectionne, true);
                    RafraichirPlatsDispo();
                    RafraichirCommande();
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas suffisament d'ingrédients pour ajouter un plat de plus",
                        "Attention",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }


        private void ReinitialiserCommande()
        {
            RetournerLesPlats(_commandeEnCours);
            _commandeEnCours = new Commande();
            RafraichirCommande();
        }

        private void RetournerLesPlats(Commande commande)
        {
            foreach (PlatCommande platsCommande in commande.PlatsCommandes)
            {
                for (int i = 0; i < platsCommande.Quantite; i++)
                {
                    foreach (Ingredient ingredient in platsCommande.Plat.Recette.Ingredients)
                    {
                        MettreAJourQuantiteAliment(ingredient, false);
                    }
                }
            }
        }
    }
}