using MongoDB.Bson;
using System;

namespace TP214E.Data
{
    public class Aliment : Produit
    {
        public Aliment(string nom, int quantite, bool congele, DateTime dateExpiration) : base(nom)
        {
            Quantite = quantite;
            Congele = congele;
            DateExpiration = dateExpiration;
        }
        public int Quantite { get; set; }
        public bool Congele { get; set; }
        public DateTime DateExpiration { get; set; }

        public string CongeleAsString => Congele ? "Congelé" : "Non-Congelé";
    }
}