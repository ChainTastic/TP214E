using System;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Ingredient : IQuantite
    {
        private int _quantite;

        public Ingredient(Aliment aliment, int quantite)
        {
            Aliment = aliment;
            Quantite = quantite;
        }

        public Aliment Aliment { get; set; }

        public int Quantite
        {
            get => _quantite;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La quantite ne peut pas être négatif");
                }

                _quantite = value;
            }
        }
    }
}