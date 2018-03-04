using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminal.Repository;
using NationalCriminal.Service;
using NationalCriminal.DAL;
using System;

namespace NationalCriminal.Tests.Services
{
    [TestClass]
    public class CriminalProfileServiceTest
    {
        private Mock<ICriminalProfileRepository> _mockRepository;
        private ICriminalProfileService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<CriminalProfile> listCriminalProfile;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICriminalProfileRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new CriminalProfileService(_mockUnitWork.Object, _mockRepository.Object);
            listCriminalProfile = new List<CriminalProfile>() {
             new CriminalProfile() { CriminalName = "Test Criminal 1",AddedToSystem=DateTime.Now },
             new CriminalProfile() { CriminalName = "Test Criminal 2",AddedToSystem=DateTime.Now },
             new CriminalProfile() { CriminalName = "Test Criminal 3",AddedToSystem=DateTime.Now },
             new CriminalProfile() { CriminalName = "Test Criminal 4",AddedToSystem=DateTime.Now },
            };
        }

        [TestMethod]
        public void CriminalProfile_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listCriminalProfile);

            //Act
            List<CriminalProfile> results = _service.GetAll() as List<CriminalProfile>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual("Test Criminal 1", results[0].CriminalName);
            Assert.AreEqual("Test Criminal 2", results[1].CriminalName);
            Assert.AreEqual("Test Criminal 3", results[2].CriminalName);
        }


        [TestMethod]
        public void Add_CriminalProfile()
        {
            //Arrange
            
            CriminalProfile criminalProfile = new CriminalProfile() { CriminalName = "Test 99" , AddedToSystem=DateTime.Now };
            _mockRepository.Setup(m => m.Add(criminalProfile)).Returns((CriminalProfile e) =>
            {
                e.CriminalName = "Test 99";
                return e;
            });
           

            //Act
            _service.Create(criminalProfile);

            //Assert
            Assert.AreEqual("Test 99", criminalProfile.CriminalName);
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
