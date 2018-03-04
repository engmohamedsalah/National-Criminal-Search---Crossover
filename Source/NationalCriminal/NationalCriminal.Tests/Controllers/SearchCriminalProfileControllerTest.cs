using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalCriminal.Controllers;
using System.Web.Mvc;
using NationalCriminal.Service;
using Moq;
using NationalCriminal.DAL;
using System.Collections.Generic;
using NationalCriminal.Models;
using System.Reflection;

namespace NationalCriminal.Tests.Controllers
{
    [TestClass]
    public class SearchCriminalProfileControllerTest
    {
        private Mock<ICountryService> _countryServiceMock;
        SearchCriminalProfileController objController;
        List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {

            _countryServiceMock = new Mock<ICountryService>();
            objController = new SearchCriminalProfileController(_countryServiceMock.Object);
            listCountry = new List<Country>() {
             new Country() { ID = 1, CountryName = "US" },
             new Country() { ID = 2, CountryName = "India" },
             new Country() { ID = 3, CountryName = "Russia" }
            };
        }
        
        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _countryServiceMock.Setup(x => x.GetAll()).Returns(listCountry);


            //Act
            var result = ((objController.GetAllCountry() as ViewResult).Model) as List<Country>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].CountryName);
            Assert.AreEqual("India", result[1].CountryName);
            Assert.AreEqual("Russia", result[2].CountryName);

        }
    }
}
