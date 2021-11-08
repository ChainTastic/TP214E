using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data
{
    public abstract class Produit
    {
        protected Produit(string nom)
        {
            Id = ObjectId.GenerateNewId();
            Nom = nom;
        }

        public ObjectId Id { get; protected set; }
        public string Nom { get; set; }
    }
}
