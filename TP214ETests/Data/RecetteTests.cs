using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class RecetteTests
    {
        private const bool congele = true;
        private const string nom_valide = "nom";
        private const int quantite_valide = 3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);

        [TestMethod()]
        public void Teste_Constructeur_Recette_valide()
        {
            List<Ingredient> lsIngredients = Get_Liste_Ingredients_Test();

            Recette recette = new Recette(nom_valide, lsIngredients);

            Assert.IsNotNull(recette.Id);
            Assert.AreEqual(nom_valide,recette.Nom);
            Assert.AreEqual(lsIngredients, recette.Ingredients);
        }

        [TestMethod()]
        public void Teste_Constructeur_liste_Invalide()
        {
            try
            {
                Recette recette = new Recette(nom_valide, new List<Ingredient>());
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Une recette doit contenir au moins un ingrédient",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_Setteur_liste_Invalide()
        {
            Recette recette = new Recette(nom_valide, Get_Liste_Ingredients_Test());

            try
            {
                recette.Ingredients = new List<Ingredient>();
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Une recette doit contenir au moins un ingrédient",
                    ex.Message);
            }
        }


        private List<Ingredient> Get_Liste_Ingredients_Test()
        {
            List<Ingredient> lsIngredients = new List<Ingredient>();
            

            for (int i = 0; i < 3; i++)
            {
                Aliment alimentTest = new Aliment(nom_valide + i, quantite_valide , congele, dateExpiration_valide);

                Ingredient ingredient = new Ingredient(alimentTest, i + 1);

                lsIngredients.Add(ingredient);
            }
          
            return lsIngredients;
        }
    }
}