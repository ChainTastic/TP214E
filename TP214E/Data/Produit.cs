using System;
using MongoDB.Bson;

namespace TP214E.Data
{
    public abstract class Produit
    {
        private string _nom;

        protected Produit(string nom)
        {
            Id = ObjectId.GenerateNewId();
            Nom = nom;
        }

        public ObjectId Id { get; protected set; }

        public string Nom
        {
            get => _nom;
            set
            {
                if (value == "" || value is null)
                {
                    throw new ArgumentException("Le nom est vide.");
                }

                _nom = value;
            }
        }
    }
}