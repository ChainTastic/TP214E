using System.Windows;
using System.Windows.Controls;
using TP214E.Data;
using TP214E.Formulaires;

namespace TP214E
{
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

            if (button.DataContext is Aliment alimentSelectionne)
            {
                dal.RetirerAliment(alimentSelectionne);
                PageAccueil.Inventaire.SupprimerAliment(alimentSelectionne);
                RafraichirInventaire();
            }
        }

        private void btnModifer_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;

            if (button.DataContext is Aliment alimentSelectionne)
            {
                FormulaireAjoutModifAliment formAjoutModifAliment = new FormulaireAjoutModifAliment(alimentSelectionne);
                if (formAjoutModifAliment.ShowDialog() == true)
                {
                    dal.ModifierAliment(alimentSelectionne.Id, formAjoutModifAliment.Aliment);
                    PageAccueil.Inventaire.ModifierAliment(formAjoutModifAliment.Aliment);
                    RafraichirInventaire();
                }
            }
        }


        private void RafraichirInventaire()
        {
            PageAccueil.Inventaire.LstAliments = dal.Aliments();
            lstBoxAliments.ItemsSource = PageAccueil.Inventaire.LstAliments;
        }


        private void BtnAjouter_OnClick(object sender, RoutedEventArgs e)
        {
            FormulaireAjoutModifAliment formAjoutModifAliment = new FormulaireAjoutModifAliment();
            if (formAjoutModifAliment.ShowDialog() == true)
            {
                dal.AjouterAliment(formAjoutModifAliment.Aliment);
                PageAccueil.Inventaire.AjouterAliment(formAjoutModifAliment.Aliment);
                RafraichirInventaire();
            }
        }
    }
}