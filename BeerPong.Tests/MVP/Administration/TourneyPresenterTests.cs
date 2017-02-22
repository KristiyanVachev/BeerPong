using System;
using BeerPong.Models;
using BeerPong.MVP;
using BeerPong.MVP.Administration.Tourneys;
using BeerPong.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.MVP.Administration
{
    [TestFixture]
    public class TourneyPresenterTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenAnArgumentIsNull()
        {
            var mockView = new Mock<ITourneyView>();
            var mockFactory = new Mock<IViewModelFactory>();

            Assert.Throws<ArgumentNullException>(() => new TourneyPresenter(mockView.Object, null, mockFactory.Object));
        }

        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            var mockView = new Mock<ITourneyView>();
            var mockService = new Mock<ITourneyService>();
            var mockFactory = new Mock<IViewModelFactory>();

            mockService.Setup(s => s.GetById(It.IsAny<int>())).Returns(new Tourney());

            var presenter = new TourneyPresenter(mockView.Object, mockService.Object, mockFactory.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
