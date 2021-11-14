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
        [TestMethod()]
        public void Teste_Ajout_recette_Dal()
        {

        }

        [TestMethod()]
        public void Teste_Ajout_Aliment_Dal()
        {
            var DALMock = new Mock<IDAL>();
        }
    }
}