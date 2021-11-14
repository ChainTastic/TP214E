using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class InventaireTests
    {
        [TestMethod()]
        public void Test()
        {
            Inventaire inventaire = new Inventaire();


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
    }
}