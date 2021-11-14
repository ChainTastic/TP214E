using System;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Aliment : Produit, IQuantite, IAliment
    {
        private int _quantite;

        private DateTime _dateExpiration;

        public Aliment(string nom, int quantite, bool congele, DateTime dateExpiration) : base(nom)
        {
            Quantite = quantite;
            Congele = congele;
            DateExpiration = dateExpiration;
        }

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

        public bool Congele { get; set; }

        public DateTime DateExpiration
        {
            get => _dateExpiration;
            set
            {
                DateTime aujourdhuiDateTime = DateTime.Today;

                int result = DateTime.Compare(value, aujourdhuiDateTime);

                if (result < 0)
                {
                    throw new ArgumentException("L'aliment a dépassé la date d'expiration");
                }

                _dateExpiration = value;
            }
        }

        public string CongeleAsString => Congele ? "Congelé" : "Non-Congelé";
    }
}