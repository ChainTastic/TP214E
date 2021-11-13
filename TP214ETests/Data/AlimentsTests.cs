using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;
using TP214E.Interface;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AlimentTests
    {
        private const bool congele = true;

        private const string nom_valide = "nom";
        private const int quantite_valide = 3;
        private DateTime dateExpiration_valide = new DateTime(DateTime.MaxValue.Ticks);


        private const string nom_invalide = "";
        private const int quantite_invalide = -3;
        private DateTime dateExpiration_invalide = new DateTime(DateTime.MinValue.Ticks);
        

        [TestMethod()]
        public void Teste_Constructeur_Aliment_valide()
        {
            var alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);

            Assert.IsNotNull(alimentTest.Id);
            Assert.AreEqual(nom_valide, alimentTest.Nom); 
            Assert.AreEqual(congele, alimentTest.Congele);
            Assert.AreEqual("Congelé", alimentTest.CongeleAsString);
            Assert.AreEqual(quantite_valide, alimentTest.Quantite);
            Assert.AreEqual(dateExpiration_valide,alimentTest.DateExpiration);
        }

        [TestMethod()]
        public void Teste_Constructeur_Aliment_Nom_Invalide()
        {
            try
            {
                var alimentTest = new Aliment(nom_invalide, quantite_valide, congele, dateExpiration_valide);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Le nom est vide.",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_Constructeur_Aliment_Quantite_Invalide()
        {
            try
            {
                var alimentTest = new Aliment(nom_valide, quantite_invalide, congele, dateExpiration_valide);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La quantite ne peut pas être négatif",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_Constructeur_Aliment_DateExpiration_Invalide()
        {
            try
            {
                var alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_invalide);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("L'aliment a dépassé la date d'expiration",
                    ex.Message);
            }
        }


        [TestMethod()]
        public void Teste_set_nom_Aliment()
        {
            var alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);

            try
            {
                alimentTest.Nom = nom_invalide;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Le nom est vide.",
                    ex.Message);
            }
        }

        [TestMethod()]
        public void Teste_set_quantite_Aliment()
        {
            var alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);

            try
            {
                alimentTest.Quantite = quantite_invalide;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La quantite ne peut pas être négatif",
                    ex.Message);
            }
        }


        [TestMethod()]
        public void Teste_set_DateExpiration_Aliment()
        {
            var alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);

            try
            {
                alimentTest.DateExpiration = dateExpiration_invalide;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("L'aliment a dépassé la date d'expiration",
                    ex.Message);
            }
        }
    }
}