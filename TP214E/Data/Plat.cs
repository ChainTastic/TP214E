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
        private double _prix;

        private string _description;

        public Plat(string nom, double prix, string description, Recette recette, TypeDePlat typePlat) : base(nom)
        {
            Prix = prix;
            Description = description;
            TypePlat = typePlat;
            Recette = recette;
        }

        public double Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Le prix ne peut pas être négatif");
                }

                _prix = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value == "" || value is null)
                {
                    throw new ArgumentException("La description est vide.");
                }

                _description = value;
            }
        }

        public TypeDePlat TypePlat { get; set; }
        public Recette Recette { get; set; }
        public string TypePlatAsString => TypePlat.ToString();

        public bool VerifierDisponibilite()
        {
            return Recette.VerifierDisponibilite();
        }
    }

    
}
