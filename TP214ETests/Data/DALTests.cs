using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class DALTests
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
        public void Teste_Ajout_recette_Dal()
        {
            var DALMock = new Mock<IDAL>();

            //configuration du mock pour que la fausse voiture retourne True 
            //si sa méthode peutPrendreLaRoute est appelée

            DALMock.Setup(x => x.AjouterRecette(Recette_Test_objet())).Returns(true);

            DALMock.Verify(x => x.AjouterRecette(Recette_Test_objet()));
        }

        [TestMethod()]
        public void Teste_Ajout_Aliment_Dal()
        {
            var DALMock = new Mock<IDAL>();
            
            //configuration du mock pour que la fausse voiture retourne True 
            //si sa méthode peutPrendreLaRoute est appelée

            DALMock.Setup(x => x.AjouterRecette(Recette_Test_objet())).Returns(true);

            DALMock.Setup(x => x.AjouterAliment(Get_Aliment_Test())).Returns(true);
        }


        private void lol()
        {
            //var voitureMock = new Mock<IVoiture>();

            ////configuration du mock pour que la fausse voiture retourne True 
            ////si sa méthode peutPrendreLaRoute est appelée
            //voitureMock.Setup(x => x.peutPrendreLaRoute()).Returns(true);

            //var garage = new Garage();

            ////act
            ////on appel la fonction que l'on veut tester avec notre faux objet
            //garage.TesterVoiture(voitureMock.Object);

            ////assert
            //voitureMock.Verify(x => x.Roule());
        }

        private Recette Recette_Test_objet()
        {
            List<Ingredient> lsIngredients = new List<Ingredient>();

            for (int i = 0; i < 3; i++)
            {
                Aliment alimentTest = new Aliment(nom_valide + i, quantite_valide, congele, dateExpiration_valide);

                Ingredient ingredient = new Ingredient(alimentTest, 1);

                lsIngredients.Add(ingredient);
            }

            Recette recette = new Recette(nom_valide, lsIngredients);

            return recette;
        }

        private Aliment Get_Aliment_Test()
        {
            Aliment alimentTest = new Aliment(nom_valide, quantite_valide, congele, dateExpiration_valide);
            return alimentTest;
        }
    }
}