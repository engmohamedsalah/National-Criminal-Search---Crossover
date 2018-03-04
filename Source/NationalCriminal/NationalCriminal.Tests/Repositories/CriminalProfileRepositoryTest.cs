using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Linq;
using NationalCriminal.Repository;
using NationalCriminal.DAL;
using System.Data.Linq;
using System;

namespace NationalCriminal.Tests.Repositories
{
    [TestClass]
    public class CriminalProfileRepositoryTest
    {
        
        DataContext databaseContext;
        ICriminalProfileRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            //connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext =new  NationalCriminalDataContext();
            objRepo = new CriminalProfileRepository();
           
        }

        [TestMethod]
        public void CriminalProfile_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("Alexander Butt", result[0].CriminalName);
            Assert.AreEqual("Alexanderson hill", result[1].CriminalName);
            Assert.AreEqual("Sara Palm", result[2].CriminalName);
        }

        [TestMethod]
        public void CriminalProfile_Repository_Create()
        {
            //Arrange
            CriminalProfile c = new CriminalProfile() {CriminalName  = "Test", AddedToSystem = DateTime.Now,NationalityID = 10, Sex ='m' };
            objRepo.Delete(a=>a.CriminalName == "Test");
            //Act
            var result = objRepo.Add(c);
            objRepo.Save();

            var lst = objRepo.GetAll().ToList();

            //Assert

           
            Assert.AreEqual("Test", lst.Last().CriminalName); 
        }
    }
}
