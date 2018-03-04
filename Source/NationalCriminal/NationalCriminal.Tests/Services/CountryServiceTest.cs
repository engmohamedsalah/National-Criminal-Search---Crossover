using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminal.Repository;
using NationalCriminal.Service;
using NationalCriminal.DAL;

namespace NationalCriminal.Tests.Services
{
    [TestClass]
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _mockRepository;
        private ICountryService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new CountryService(_mockUnitWork.Object, _mockRepository.Object);
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
            _mockRepository.Setup(x => x.GetAll()).Returns(listCountry);

            //Act
            List<Country> results = _service.GetAll() as List<Country>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        [TestMethod]
        public void Add_Country()
        {
            //Arrange
            int Id = 1;
            Country contry = new Country() { CountryCode = "TC" };
            _mockRepository.Setup(m => m.Add(contry)).Returns((Country e) =>
            {
                e.ID = Id;
                return e;
            });
           

            //Act
            _service.Create(contry);

            //Assert
            Assert.AreEqual(Id, contry.ID);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }





















        /////////// dummy 

        /// <summary>
        /// dummy start here
        /// </summary>

        public class RetObj {
        
        }

        public interface IObject
        {
            RetObj AnotherMethod();
        }

        public RetObj MyMethod(IObject obj)
        {
            var ret = obj.AnotherMethod();
            return ret;
        }


        public void Test() {
            
            //Arrange           
            Mock<IObject> _mockObj = new Mock<IObject>();

            var dummyVal = new RetObj(); 
            _mockObj.Setup(x => x.AnotherMethod()).Returns(dummyVal);

            //Act
            var result = MyMethod(_mockObj.Object);


            //Assert
            Assert.Equals(dummyVal, result);         
        }





    }
}
