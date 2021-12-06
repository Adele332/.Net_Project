using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using CatApp.DataProvider;

namespace MoqTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var provider = new Mock<ICatDataProvider>(MockBehavior.Strict);
            var repo = new Repository(provider.Object);

            provider.Setup(m => m.GetAboutBreed("ben")).Returns(new List<AboutBreedModel>
            {
                    new AboutBreedModel {id = "beng", name = "bengal", alt_names = "Bengal", 
                        origin = "United States", temperament = "Energetic, Demanding, Intelligent"},
                    new AboutBreedModel {id = "sing", name = "singapura", alt_names = "non",
                        origin = "United States", temperament = "Alert, Agile, Curious",
                        description = "The Singapura is usually..."},

            });
            Assert.AreEqual(1, repo.CountResults("ben"));
        }
    }
}
