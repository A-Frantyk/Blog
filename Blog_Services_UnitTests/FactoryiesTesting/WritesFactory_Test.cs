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

namespace Blog_Services_UnitTests.FactoryiesTesting
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
        public void CreaeMethodTestIsNotReturnNull_Test()
        {
            // Arrange

            var modelWritesObj = new Writes()
            {
                Title = "TestTitle"
            };

            // Act
            var realResult = factory.Create(modelWritesObj);

            // Assert
            Assert.IsNotNull(realResult, "WritesDTO is NULL!!!");
        }

        [Test]
        public void CreateMethodEqualProps_Test()
        {
            // Arrange

            var modelWritesObj = new Writes()
            {
                Title = "TestTitle"
            };

            // Act

            var realResult = factory.Create(modelWritesObj);

            // Assert
            Assert.AreEqual(realResult.Title, modelWritesObj.Title);
        }

        [Test]
        public void CreateMethodForExpectedException_Test()
        {
            // Arrange

            // Act

            Writes writes = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => factory.Create(writes));
        }
    }
}
