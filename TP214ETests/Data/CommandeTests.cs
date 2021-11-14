using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTests
    {
        private const double TauxTPS = 5;
        private const double TauxTVQ = 9.975;
        private const bool congele = true;
        private const string nom_valide = "nom";
        private const string description_valide = "description";
        private const int quantite_valide = 3;
        private const double prix_valide = 3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);

        [TestMethod()]
        public void Teste_Constructeur_valide()
        {
            Commande commande = new Commande();

            Assert.IsNotNull(commande.Id);
            Assert.IsNotNull(commande.Date);
        }


        [TestMethod()]
        public void Teste_Setteur_List_valide()
        {
            Commande commande = new Commande();

            List<PlatCommande> lsPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lsPlatCommandestest;

            Assert.AreEqual(lsPlatCommandestest,commande.PlatsCommandes);
        }

        [TestMethod()]
        public void Teste_Setteur_List_Invalide()
        {
            Commande commande = new Commande();

            try
            {
                commande.PlatsCommandes = new List<PlatCommande>();
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Une commande ne peut pas avoir aucun plat.",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_RetirerPlat_List()
        {
            Commande commande = new Commande();

            List<PlatCommande> lstPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lstPlatCommandestest;

            commande.RetirerPlat(lstPlatCommandestest[0]);

            Assert.AreEqual(1, commande.PlatsCommandes.Count );
           
        }

        [TestMethod()]
        public void Teste_AjoutPlat_List()
        {
            Commande commande = new Commande();

            List<PlatCommande> lstPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lstPlatCommandestest;
        
            commande.AjouterPlat(lstPlatCommandestest[0]);

            Assert.AreEqual(3, commande.PlatsCommandes.Count);
        }

        [TestMethod()]
        public void Teste_CalculerSousTotal()
        {
            Commande commande = new Commande();

            List<PlatCommande> lstPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lstPlatCommandestest;

            commande.CalculerSousTotal();

            double sousTotal = 0;

            foreach (PlatCommande platCommande in lstPlatCommandestest)
            {
                sousTotal += platCommande.SousTotal;
            }

            Assert.AreEqual(sousTotal, commande.CalculerSousTotal());
        }

        [TestMethod()]
        public void Teste_CalculerTVQ()
        {
            Commande commande = new Commande();

            List<PlatCommande> lstPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lstPlatCommandestest;

            commande.CalculerSousTotal();

            double sousTotal = (commande.CalculerSousTotal() * (TauxTVQ / 100));

            Assert.AreEqual(sousTotal, commande.CalculerTVQ());
        }

        [TestMethod()]
        public void Teste_CalculerTPS()
        {
            Commande commande = new Commande();

            List<PlatCommande> lstPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lstPlatCommandestest;

            double sousTotal = (commande.CalculerSousTotal() * (TauxTPS / 100));

            Assert.AreEqual(sousTotal, commande.CalculerTPS());
        }

        [TestMethod()]
        public void Teste_CalculerTotal()
        {
            Commande commande = new Commande();

            List<PlatCommande> lstPlatCommandestest = PlatCommandeList_Test_objet();

            commande.PlatsCommandes = lstPlatCommandestest;

            double Total = commande.CalculerSousTotal() + commande.CalculerTPS() + commande.CalculerTVQ();

            Assert.AreEqual(Total, commande.CalculerTotal());
        }

        private List<PlatCommande> PlatCommandeList_Test_objet()
        {
            List<Ingredient> lsIngredients = new List<Ingredient>();

            int quantite;

            for (int i = 0; i < 3; i++)
            {
                Aliment alimentTest = new Aliment(nom_valide + i, quantite_valide, congele, dateExpiration_valide);

                Ingredient ingredient = new Ingredient(alimentTest, 1);

                lsIngredients.Add(ingredient);
            }

            Recette recette1 = new Recette(nom_valide, lsIngredients);

            Recette recette2 = new Recette(nom_valide + 1, lsIngredients);

            Plat platTest1 = new Plat(nom_valide, prix_valide, description_valide, recette1, TypeDePlat.Burger);
            Plat platTest2 = new Plat(nom_valide, prix_valide, description_valide, recette2, TypeDePlat.Burger);

            PlatCommande platCommandeTest1 = new PlatCommande(platTest1, quantite_valide);
            PlatCommande platCommandeTest2 = new PlatCommande(platTest2, quantite_valide);

            List<PlatCommande> lsPlatCommandestest = new List<PlatCommande>();

            lsPlatCommandestest.Add(platCommandeTest1);
            lsPlatCommandestest.Add(platCommandeTest2);

            return lsPlatCommandestest;
        }
    }
}