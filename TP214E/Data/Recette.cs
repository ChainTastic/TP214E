using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Recette : Produit, IDisponible
    {
        private List<Ingredient> _ingredients;

        public Recette(string nom, List<Ingredient> lstIngredients) : base(nom)
        {
            if (lstIngredients.Count == 0)
            {
                throw new ArgumentException("Une recette doit contenir au moins un ingrédient");
            }

            Ingredients = lstIngredients;
        }

        public List<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Une recette doit contenir au moins un ingrédient");
                }

                _ingredients = value;
            }
        }

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
