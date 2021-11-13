using System;
using System.Collections.Generic;
using System.Text;
using TP214E.Interface;

namespace TP214E.Data
{
    public class PlatCommande: IQuantite
    {
        private int _quantite;

        public PlatCommande(Plat platEnCommande, int quantite)
        {
            Plat = platEnCommande;
            Quantite = quantite;
        }

        public Plat Plat { get; set; }

        public int Quantite
        {
            get
            {
                return _quantite;
            }
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