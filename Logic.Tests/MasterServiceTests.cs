using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Logic.Tests
{
    [TestFixture]
    public class MasterServiceTests
    {
        IMasterService mService;

        [Test]
        public void GetDoubleSum_When_datService_returns_null_Then_get_exception()
        {
            // Arrange
            var datService = A.Fake<IDataService>();
            A.CallTo(() => datService.GetAllData()).Returns<IEnumerable<int>>(null);

            var algService = A.Fake<IAlgoService>();
            A.CallTo(() => algService.DoubleSum(A<IEnumerable<int>>._)).Returns(0);
            
            mService = new MasterService(algService, datService);

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => mService.GetDoubleSum());
        }

        [Test]
        public void GetDoubleSum_When_datService_returns_empty_collection_Then_get_exception()
        {
            // Arrange
            var datService = A.Fake<IDataService>();
            A.CallTo(() => datService.GetAllData()).Returns<IEnumerable<int>>(new List<int>() );

            var algService = A.Fake<IAlgoService>();
            A.CallTo(() => algService.DoubleSum(A<IEnumerable<int>>._)).Returns(0);

            mService = new MasterService(algService, datService);

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => mService.GetDoubleSum());
        }

    }
}
