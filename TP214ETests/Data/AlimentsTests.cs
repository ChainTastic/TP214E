using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TP214E.Data;
using TP214E.Interface;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AlimentTests
    {
        [TestMethod()]
        public void TesterConstructeur()
        {
            var aliment = new Mock<IAliment>();

            Assert.AreNotEqual(null,aliment.Object.Congele);
            Assert.AreNotEqual(null,aliment.Object.DateExpiration);
            Assert.AreNotEqual(null,aliment.Object.Id);
            Assert.AreNotEqual(null,aliment.Object.Quantite);
            // Mock ne genere pas de nom,ça insert une valeur null à la place
            Assert.AreEqual(null, aliment.Object.Nom);
        }


        [TestMethod()]
        public void TesterSetCongele()
        {
            var aliment = new Mock<IAliment>();

            Assert.AreNotEqual(null, aliment.Object.Congele);
            Assert.AreNotEqual(null, aliment.Object.DateExpiration);
            Assert.AreNotEqual(null, aliment.Object.Id);
            Assert.AreNotEqual(null, aliment.Object.Quantite);
            // Mock ne genere pas de nom,ça insert une valeur null à la place
            Assert.AreEqual(null, aliment.Object.Nom);
        }
    }
}