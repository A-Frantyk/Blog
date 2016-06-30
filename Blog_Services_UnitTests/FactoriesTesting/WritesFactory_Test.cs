using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using Blog_Services.UnitOfWork;
using Blog_Services.ModelDTO;
using Blog_Entity.Model;
using Blog_Services.Factory;
using Ninject;

namespace Blog_Services_UnitTests.FactoriesTesting
{
    [TestFixture]
    public class WritesFactory_Test
    {
        Mock<IUnitOfWork> mockUnit = null;
        //Mock<IFactory<WritesDTO, Writes>> factoryMock = null;

        Writes_Factory factory = null;

        [SetUp]
        public void SetUp()
        {
            mockUnit = new Mock<IUnitOfWork>();
            factory = new Writes_Factory(mockUnit.Object);
            //factoryMock = new Mock<IFactory<WritesDTO, Writes>>(mockUnit.Object);
        }

        [Test]
        public void CreaeMethodTest_IsNotReturnNull()
        {
            // Arrange

            WritesDTO writes = new WritesDTO()
            {
                Title = "TestTitle"
            };

            var modelWritesObj = new Writes()
            {
                Title = "TestTitle"
            };

            // Act
            var realResult = factory.Create(modelWritesObj);

            // Assert
            Assert.AreEqual(writes.Title, realResult.Title);
        }
    }
}
