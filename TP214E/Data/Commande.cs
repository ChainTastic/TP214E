using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    class Commande : Produit, IDisponible
    {
        public Commande(string nom, List<Plat> lstPlats) : base(nom)
        {
            LstPlats = lstPlats;
        }

        public List<Plat> LstPlats { get; set; }

        public bool VerifierDisponibilite()
        {
            foreach (Plat plat in LstPlats)
            {
                if (!plat.VerifierDisponibilite())
                {
                    return false;
                }
            }
            return true;
        }

    }
}
