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

namespace TP214E.Formulaires
{
    /// <summary>
    /// Interaction logic for FormulaireAjoutModifAliment.xaml
    /// </summary>
    public partial class FormulaireAjoutModifAliment : Window
    {

        public Aliment Aliment { get; private set; }

        public FormulaireAjoutModifAliment()
        {
            InitializeComponent();
        }

        public FormulaireAjoutModifAliment(Aliment alimentAModifier)
        {
            InitializeComponent();

            Aliment = alimentAModifier;

            if (Aliment != null)
            {
                txtNom.Text = alimentAModifier.Nom;
                txtQuantite.Text = alimentAModifier.Quantite.ToString();
                if (Aliment.Congele)
                {
                    rbCongele.IsChecked = true;
                }
                else
                {
                    rbNonCongele.IsChecked = true;
                }

                dpDateExpiration.SelectedDate = alimentAModifier.ExpireLe;

            }

        }

        private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            ValiderAlimentFormulaire();

        }

        private void ValiderAlimentFormulaire()
        {
            try
            {
                bool estCongele = VerifierAlimentCongele(rbCongele);
                if (FormulaireEstValide())
                {
                    Aliment = new Aliment(txtNom.Text.Trim(), Convert.ToInt32(txtQuantite.Text), estCongele, dpDateExpiration.SelectedDate.Value);
                    DialogResult = true;
                }
            }
            catch (ArgumentException erreur)
            {
                MessageBox.Show(erreur.Message);
            }
        }

        private bool FormulaireEstValide()
        {
            if (ChampsRemplis() && QuantiteContientNombre(txtQuantite.Text))
            {
                return true;
            }

            return false;
        }

        private bool ChampsRemplis()
        {
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtQuantite.Text))
            {
                EnvoyerMessageChampNonRemplis();
                return false;
            }

            if (rbCongele.IsChecked == false && rbNonCongele.IsChecked == false)
            {
                EnvoyerMessageChampNonRemplis();
                return false;
            }

            if (!dpDateExpiration.SelectedDate.HasValue)
            {
                EnvoyerMessageChampNonRemplis();
                return false;
            }

            return true;
        }

        private void EnvoyerMessageChampNonRemplis()
        {
            MessageBox.Show(
                "Veuilez vous assurez de bien remplir tout les champs",
                "Attention",
                MessageBoxButton.OK,
                MessageBoxImage.Warning
            );
        }

        private bool QuantiteContientNombre(string textQuantite)
        {
            int quantite;
            if (!int.TryParse(textQuantite, out quantite))
            {
                MessageBox.Show(
                    "La valeur entré pour le champ quantité n'est pas valide. Veuillez entrer un nombre entier.", 
                    "Erreur",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error
                    );
                return false;
            }

            return true;
        }

        private bool VerifierAlimentCongele(RadioButton boutonEstCongele)
        {
            return boutonEstCongele.IsChecked != null && (bool) boutonEstCongele.IsChecked;
        }
    }
}
