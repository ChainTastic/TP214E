using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MongoDB.Bson;
using Moq.Language;
using TP214E.Interface;

namespace TP214E.Data
{
    public enum TypeDePlat
    {
        Entree,
        Burger,
        Poutine,
        Club,
        Salade,
        Enfant,
        Dessert,
    }

    public class Plat : Produit, IDisponible
    {
        public Plat(string nom, double prix, string description, Recette recette, TypeDePlat typePlat) : base(nom)
        {
            Prix = prix;
            Description = description;
            TypePlat = typePlat;
            Recette = recette;
        }

        public double Prix { get; set; }
        public string Description { get; set; }
        public TypeDePlat TypePlat { get; set; }
        public Recette Recette { get; set; }

        public bool VerifierDisponibilite()
        {
            return Recette.VerifierDisponibilite();
        }

        public string TypePlatAsString => TypePlat.ToString();

    }

    
}
