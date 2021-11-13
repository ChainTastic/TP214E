using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class IngredientTest
    {
        private const bool congele = true;
        private const string nom_valide = "nom";
        private const int quantite_valide = 3;
        private const int quantite_invalide = -3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);

        [TestMethod()]
        public void Teste_Constructeur_Ingredient_valide()
        {
            Aliment alimentTest = Get_Aliment_Test();
            Ingredient ingredientTest = new Ingredient(alimentTest, quantite_valide);
            
            Assert.AreEqual(alimentTest,ingredientTest.Aliment);
            Assert.AreEqual(quantite_valide, ingredientTest.Quantite);
        }

        [TestMethod()]
        public void Teste_Constructeur_Ingredient_Invalide()
        {
            Aliment alimentTest = Get_Aliment_Test();

            try
            {
                Ingredient ingredientTest = new Ingredient(alimentTest, quantite_invalide);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La quantite ne peut pas être négatif",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_Setteur_Ingredient_Quantite_Invalide()
        {
            Aliment alimentTest = Get_Aliment_Test();
            Ingredient ingredientTest = new Ingredient(alimentTest, quantite_valide);

            try
            {
                ingredientTest.Quantite = quantite_invalide;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La quantite ne peut pas être négatif",
                    ex.Message);
            }
        }

        private Aliment Get_Aliment_Test()
        {
            Aliment alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);
            return alimentTest;
        }
    }
}