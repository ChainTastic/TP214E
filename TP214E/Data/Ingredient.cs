using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Ingredient
    {
        public Ingredient(Aliment aliment, int quantite)
        {
            Aliment = aliment;
            Quantite = quantite;
        }

        public Aliment Aliment { get; set; }
        public int Quantite { get; set; }

    }
}
