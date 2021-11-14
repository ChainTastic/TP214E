using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class InventaireTests
    {
        private const bool congele = true;
        private const string nom_valide = "nom";
        private const string description_valide = "description";
        private const int quantite_valide = 3;
        private const double prix_valide = 3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);

        [TestMethod()]
        public void TestConstructeurVide()
        {
            Inventaire inventaire = new Inventaire();

            Assert.AreEqual(0,inventaire.LstRecettes.Count);
            Assert.AreEqual(0,inventaire.LstAliments.Count);
            Assert.AreEqual(0,inventaire.LstCommandesTraite.Count);
            Assert.AreEqual(0,inventaire.LstPlats.Count);
        }

        [TestMethod()]
        public void TestInventaireAjoutAliment()
        {
            Inventaire inventaire = new Inventaire();

            inventaire.AjouterAliment(Get_Aliment_Test());

            Assert.AreEqual(1, inventaire.LstAliments.Count);
        }

        [TestMethod()]
        public void TestInventaireSupressionAliment()
        {
            Inventaire inventaire = new Inventaire();

            Aliment aliment = Get_Aliment_Test();

            inventaire.AjouterAliment(aliment);

            inventaire.SupprimerAliment(aliment);

            Assert.AreEqual(0, inventaire.LstAliments.Count);
        }

        [TestMethod()]
        public void TestInventaireAjoutCommande()
        {
            Inventaire inventaire = new Inventaire();

            inventaire.AjouterCommande(Commande_Test_Object());

            Assert.AreEqual(1, inventaire.LstCommandesTraite.Count);
        }

        [TestMethod()]
        public void TestInventaireSupressionCommande()
        {
            Inventaire inventaire = new Inventaire();

            Commande commande = Commande_Test_Object();

            inventaire.AjouterCommande(commande);

            inventaire.SupprimerCommande(commande);

            Assert.AreEqual(0, inventaire.LstCommandesTraite.Count);
        }

        private Aliment Get_Aliment_Test()
        {
            Aliment alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);
            return alimentTest;
        }

        private Recette recette_Test_objet()
        {
            List<Ingredient> lsIngredients = new List<Ingredient>();

            for (int i = 0; i < 3; i++)
            {
                Aliment alimentTest = new Aliment(nom_valide + i, quantite_valide, congele, dateExpiration_valide);

                Ingredient ingredient = new Ingredient(alimentTest, 1);

                lsIngredients.Add(ingredient);
            }

            Recette recette = new Recette(nom_valide , lsIngredients);

            return recette;
        }

        private Commande Commande_Test_Object()
        {
            Plat platTest = new Plat(nom_valide, prix_valide, description_valide, recette_Test_objet(), TypeDePlat.Burger);

            PlatCommande platCommandeTest = new PlatCommande(platTest, quantite_valide);

            List<PlatCommande> lstPlatCommandestest = new List<PlatCommande>();

            lstPlatCommandestest.Add(platCommandeTest);

            Commande commande = new Commande();

            commande.PlatsCommandes = lstPlatCommandestest;

            return commande;
        }
    }
}