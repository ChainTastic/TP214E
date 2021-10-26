using System.Collections.Generic;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private List<Aliment> aliments;

        public PageInventaire(DAL dal)
        {
            InitializeComponent();
            aliments = dal.ALiments();
        }
    }
}