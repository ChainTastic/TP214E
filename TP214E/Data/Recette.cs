using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Recette : Produit, IDisponible
    {
        public Recette(string nom, List<Ingredient> ingredients) : base(nom)
        {
            Ingredients = ingredients;
        }

        public List<Ingredient> Ingredients { get; set; }

        public bool VerifierDisponibilite()
        {
            if (Ingredients.Count == 0)
            {
                return false;
            }

            foreach (var ingredient in Ingredients)
            {
                Aliment aliment =
                    PageAccueil.Inventaire.LstAliments.Find(aliment => aliment.Id == ingredient.Aliment.Id);
                if (aliment.Quantite < ingredient.Quantite)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
