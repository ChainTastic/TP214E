using System;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E.Formulaires
{
    /// <summary>
    ///     Interaction logic for FormulaireAjoutModifAliment.xaml
    /// </summary>
    public partial class FormulaireAjoutModifAliment : Window
    {
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
                    rbCongele.IsChecked = true;
                else
                    rbNonCongele.IsChecked = true;

                dpDateExpiration.SelectedDate = alimentAModifier.DateExpiration;
            }
        }

        public Aliment Aliment { get; private set; }

        private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            if (!ChampsFormulaireRemplis())
            {
                EnvoyerMessageAvertissement("Veuilez vous assurez de bien remplir tous les champs");
            }
            else
            {
                try
                {
                    Aliment = Aliment == null ? CreerNouvelleAliment() : ModifierAliment(Aliment);
                    DialogResult = true;
                }
                catch (ArgumentException erreur)
                {
                    EnvoyerMessageAvertissement(erreur.Message);
                }
            }
        }

        private Aliment ModifierAliment(Aliment alimentAModifier)
        {
            alimentAModifier.Nom = txtNom.Text.Trim();
            alimentAModifier.Quantite = Convert.ToInt32(txtQuantite.Text);
            alimentAModifier.Congele = VerifierAlimentCongele(rbCongele);
            alimentAModifier.DateExpiration = dpDateExpiration.SelectedDate.Value.Date;
            return alimentAModifier;
        }

        private Aliment CreerNouvelleAliment()
        {
            Aliment nouvelleAliment = new Aliment(
                txtNom.Text.Trim(),
                Convert.ToInt32(txtQuantite.Text),
                VerifierAlimentCongele(rbCongele),
                dpDateExpiration.SelectedDate.Value
            );
            return nouvelleAliment;
        }

        private void EnvoyerMessageAvertissement(string messageErreur)
        {
            MessageBox.Show(messageErreur, "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        private bool ChampsFormulaireRemplis()
        {
            if (!ChampTexteRemplis(txtNom))
            {
                return false;
            }

            if (!ChampTexteRemplis(txtQuantite))
            {
                return false;
            }

            if (!ChampCongeleRemplis())
            {
                return false;
            }

            if (!ChampDateRemplis())
            {
                return false;
            }

            return true;
        }

        private bool ChampDateRemplis()
        {
            return dpDateExpiration.SelectedDate.HasValue;
        }

        private bool ChampCongeleRemplis()
        {
            return ChampRadioRemplis(rbCongele) || ChampRadioRemplis(rbNonCongele);
        }

        private bool ChampRadioRemplis(RadioButton radioButton)
        {
            return radioButton.IsChecked != null && (bool) radioButton.IsChecked;
        }


        private bool ChampTexteRemplis(TextBox champText)
        {
            return !string.IsNullOrEmpty(champText.Text);
        }


        private bool VerifierAlimentCongele(RadioButton boutonEstCongele)
        {
            return boutonEstCongele.IsChecked != null && (bool) boutonEstCongele.IsChecked;
        }
    }
}