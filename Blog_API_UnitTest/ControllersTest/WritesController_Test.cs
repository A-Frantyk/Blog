using Blog_API.Controllers;
using Blog_Entity.Model;
using Blog_Services.Factory;
using Blog_Services.ModelDTO;
using Blog_Services.UnitOfWork;
using Moq;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_API_UnitTest.ControllersTest
{
    [TestFixture]
    public class WritesController_Test
    {
        private WritesController _writesController = null;

        private Mock<IUnitOfWork> _unitMock = null;
        private Mock<IFactory<WritesDTO, Writes>> _factoryMock = null;

#pragma warning disable CS0169 // The field 'WritesController_Test._unit' is never used
        private IUnitOfWork _unit;
#pragma warning restore CS0169 // The field 'WritesController_Test._unit' is never used
#pragma warning disable CS0169 // The field 'WritesController_Test._factory' is never used
        private IFactory<WritesDTO, Writes> _factory;
#pragma warning restore CS0169 // The field 'WritesController_Test._factory' is never used

        [SetUp]
        public void SetUp()
        {
            _unitMock = new Mock<IUnitOfWork>();
            _factoryMock = new Mock<IFactory<WritesDTO, Writes>>();

            _writesController = new WritesController(_unitMock.Object, _factoryMock.Object);
        }

        //[Test]
        //public void GetWritesNotNull_Test()
        //{
        //    // Arrange

        //    // Act
        //    var writes = _writesController.GetWrites();

        //    // Assert
        //    CollectionAssert.AllItemsAreNotNull(writes);
        //}
    }
}
