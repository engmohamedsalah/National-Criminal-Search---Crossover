using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Linq;
using NationalCriminal.Repository;
using NationalCriminal.DAL;
using System.Data.Linq;

namespace NationalCriminal.Tests.Repositories
{
    [TestClass]
    public class CountryRepositoryTest
    {
#pragma warning disable CS0169 // The field 'CountryRepositoryTest.connection' is never used
        DbConnection connection;
#pragma warning restore CS0169 // The field 'CountryRepositoryTest.connection' is never used
        DataContext databaseContext;
        ICountryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            //connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext =new  NationalCriminalDataContext();
            objRepo = new CountryRepository();
           
        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("AD", result[0].CountryCode);
            Assert.AreEqual("AE", result[1].CountryCode);
            Assert.AreEqual("AF", result[2].CountryCode);
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            //Arrange
            Country c = new Country() {CountryName  = "Test Country" ,CountryCode="TC" };

            //remove if exist before add again
            //var existCountry =  objRepo.FindBy(a=>a.CountryCode =="TC");
            //if (existCountry != null && existCountry.Count() > 0)
            objRepo.Delete(a=>a.CountryCode == "TC");
            //Act
            var result = objRepo.Add(c);
            objRepo.Save();
            var lst = objRepo.GetAll().ToList();

            //Assert

           // Assert.AreEqual(192, lst.Count);
            Assert.AreEqual("Test Country", lst.Last().CountryName); 
        }
    }
}
