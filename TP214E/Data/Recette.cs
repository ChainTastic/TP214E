using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    class Recette : Produit, IDisponible
    {
        public Recette(string nom, List<(Aliment, int)> lstAlimentsQtty) : base(nom)
        {
            LstAlimentsQtty = lstAlimentsQtty;
        }

        public List<(Aliment, int)> LstAlimentsQtty { get; set; }

        public bool VerifierDisponibilite()
        {
            if (LstAlimentsQtty.Count == 0)
            {
                return false;
            }

            foreach (var alimentQuantiteTuple in LstAlimentsQtty)
            {
                if (alimentQuantiteTuple.Item1.Quantite < alimentQuantiteTuple.Item2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
