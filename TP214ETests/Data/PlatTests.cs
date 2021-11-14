using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class PlatTests
    {
        private const bool congele = true;
        private const string nom_valide = "nom";
        private const string nom_Invalide = "";
        private const string description_valide = "description";
        private const string description_Invalide = "";
        private const int quantite_valide = 3;
        private const double prix_valide = 3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);

        [TestMethod()]
        public void Teste_Constructeur_Plat_valide()
        {
            Recette recette = Recette_Test_objet(true);

            Plat platTest = new Plat(nom_valide, prix_valide, description_valide, recette, TypeDePlat.Burger);

            Assert.IsNotNull(platTest.Id);
            Assert.AreEqual(nom_valide,platTest.Nom);
            Assert.AreEqual(prix_valide, platTest.Prix);
            Assert.AreEqual(description_valide, platTest.Description);
            Assert.AreEqual(recette, platTest.Recette);
            Assert.AreEqual(TypeDePlat.Burger, platTest.TypePlat);
        }


        [TestMethod()]
        public void Teste_Constructeur_Plat_Nom_Invalide()
        {
            Recette recette = Recette_Test_objet(true);

            try
            {
                Plat platTest = new Plat(nom_Invalide, prix_valide, description_valide, recette, TypeDePlat.Burger);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Le nom est vide.",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_Constructeur_Plat_Description_Invalide()
        {
            Recette recette = Recette_Test_objet(true);

            try
            {
                Plat platTest = new Plat(nom_valide, prix_valide, description_Invalide, recette, TypeDePlat.Burger);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La description est vide.",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_fonction_VerifierDisponibilite_valide()
        {
            Recette recette = Recette_Test_objet(false);

            Plat platTest = new Plat(nom_valide, prix_valide, description_valide, recette, TypeDePlat.Burger);

            Assert.AreEqual(true, platTest.VerifierDisponibilite());
        }

        [TestMethod()]
        public void Teste_fonction_VerifierDisponibilite_Invalide()
        {
            var DALMock = new Mock<IDAL>();

            

            Recette recette = Recette_Test_objet(true);

            Plat platTest = new Plat(nom_valide, prix_valide, description_valide, recette, TypeDePlat.Burger);

            Assert.AreEqual(false, platTest.VerifierDisponibilite());
        }

        private Recette Recette_Test_objet(bool valide)
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

                Ingredient ingredient = new Ingredient(alimentTest, quantite) ;

                lsIngredients.Add(ingredient);
            }

            Recette recette = new Recette(nom_valide, lsIngredients);

            return recette;
        }

    }
}