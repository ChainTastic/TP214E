using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class PlatCommandeTests
    {
        private const bool congele = true;
        private const string nom_valide = "nom";
        private const string description_valide = "description";
        private const int quantite_valide = 3;
        private const int quantite_invalide = -3;
        private const double prix_valide = 3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);

        [TestMethod()]
        public void Teste_Constructeur_valide()
        {
            Plat platTest = Plat_Test_objet(true);

            PlatCommande platCommandeTest = new PlatCommande(platTest,quantite_valide);

            Assert.AreEqual(platTest,platCommandeTest.Plat);
            Assert.AreEqual(quantite_valide, platCommandeTest.Quantite);
        }

        [TestMethod()]
        public void Teste_Constructeur_Invalide()
        {
            Plat platTest = Plat_Test_objet(true);

            try
            {
                PlatCommande platCommandeTest = new PlatCommande(platTest, quantite_invalide);
                    Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La quantite ne peut pas être négatif",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_Setteur_Invalide()
        {
            Plat platTest = Plat_Test_objet(true);
            PlatCommande platCommandeTest = new PlatCommande(platTest, quantite_valide);

            try
            {
                platCommandeTest.Quantite = quantite_invalide;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La quantite ne peut pas être négatif",
                    ex.Message);
            }
        }
        
     
        private Plat Plat_Test_objet(bool valide)
        {
            List<Ingredient> lsIngredients = new List<Ingredient>();

            int quantite;

            if (valide)
            {
                quantite = 5;
            }
            else
            {
                quantite = 1;
            }

            for (int i = 0; i < 3; i++)
            {
                Aliment alimentTest = new Aliment(nom_valide + i, quantite_valide, congele, dateExpiration_valide);

                Ingredient ingredient = new Ingredient(alimentTest, quantite);

                lsIngredients.Add(ingredient);
            }

            Recette recette = new Recette(nom_valide, lsIngredients);

            Plat platTest = new Plat(nom_valide, prix_valide, description_valide, recette, TypeDePlat.Burger);

            return platTest;
        }
    }
}