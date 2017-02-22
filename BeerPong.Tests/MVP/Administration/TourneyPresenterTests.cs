using System;
using BeerPong.Models;
using BeerPong.MVP;
using BeerPong.MVP.Administration.Tourneys;
using BeerPong.MVP.Tourney.Details;
using BeerPong.MVP.Tourney.List;
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

        [Test]
        public void ViewMyInit_ShouldCallServiceGetProducts()
        {
            var mockView = new Mock<ITourneyView>();
            mockView.Setup(v => v.Model).Returns(new TourneyListViewModel());

            var mockFactory = new Mock<IViewModelFactory>();
            var mockedService = new Mock<ITourneyService>();

            var presenter = new TourneyPresenter(mockView.Object, mockedService.Object, mockFactory.Object);

            mockView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedService.Verify(s => s.GetTourneys(), Times.Once);
        }

        [TestCase(2)]
        [TestCase(52)]
        public void ViewProductEdit_ShouldCallServiceGetById(int id)
        {
            var mockView = new Mock<ITourneyView>();
            var mockFactory = new Mock<IViewModelFactory>();
            var mockService = new Mock<ITourneyService>();

            var presenter =
                new TourneyPresenter(mockView.Object, mockService.Object, mockFactory.Object);

            var model = new TourneyDetailsViewModel() { Id = id };
            var args = new EditTourneyEventArgs(model);
            mockView.Raise(x => x.EditTourney += null, args);

            mockService.Verify(s => s.GetById(id), Times.Once);
        }

        [TestCase(4)]
        [TestCase(12)]
        public void TestViewProductDelete_ShouldCallServiceDeleteProduct(int id)
        {
            var mockView = new Mock<ITourneyView>();
            var mockFactory = new Mock<IViewModelFactory>();
            var mockService = new Mock<ITourneyService>();

            var presenter =
                new TourneyPresenter(mockView.Object, mockService.Object, mockFactory.Object);

            var args = new DeleteTourneyEventArgs(id);
            mockView.Raise(v => v.DeleteTourney += null, args);

            mockService.Verify(s => s.DeleteTourney(id), Times.Once);
        }
    }
}
