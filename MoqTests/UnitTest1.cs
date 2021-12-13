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

            provider.Setup(m => m.GetAboutBreed("ameri")).Returns(new List<AboutBreedModel>
            {
                    new AboutBreedModel {id = "abob", name = "American Bobtail"},
                    new AboutBreedModel {id = "acur", name = "American Curl"},
                    new AboutBreedModel {id = "asho", name = "American Shorthair"},
                    new AboutBreedModel {id = "awir", name = "American Wirehair"},

            });
            Assert.AreEqual(4, repo.CountResults("ameri"));
        }
    }
}
