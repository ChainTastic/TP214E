using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class PlatCommande
    {
        public PlatCommande(Plat platEnCommande, int quantite)
        {
            Plat = platEnCommande;
            Quantite = quantite;
        }

        public Plat Plat { get; set; }

        public int Quantite { get; set; }

    }
}