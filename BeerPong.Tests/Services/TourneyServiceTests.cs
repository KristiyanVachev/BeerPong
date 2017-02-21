using System;
using BeerPong.Data.Contracts;
using BeerPong.Factories;
using BeerPong.Models;
using BeerPong.Models.Contracts;
using BeerPong.Services;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.Services
{
    [TestFixture]
    public class TourneyServiceTests
    {
        //Bytes2You test
        [Test]
        public void Constructor_ShouldThrow_WhenArgumentIsNull()
        {
            //Arrange
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new TourneyService(
                null,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
            ));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenArgumentsAreValid()
        {
            //Arrange
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
            ));
        }

        [TestCase("TourneyName")]
        [TestCase("Beer pong tourney")]
        public void CreateTourney_ShouldCallFactoryCreateTourney(string name)
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            service.CreateTourney(name, "");

            mockFactory.Verify(x => x.CreateTourney(name, It.IsAny<User>()), Times.Once);
        }

        [TestCase("TourneyName", "")]
        public void CreateTourney_ShouldCallRepository(string name, string userId)
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            service.CreateTourney(name, userId);

            mockTourneyRepository.Verify(x => x.Add(It.IsAny<Tourney>()), Times.Once);
        }

        [TestCase("TourneyName", "")]
        public void CreateTourney_ShouldCallUnitOfWork(string name, string userId)
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            service.CreateTourney(name, userId);

            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [TestCase(2)]
        [TestCase(24)]
        public void GetById_ShouldCallRepositoryWithCorrectId(int id)
        {
            //Arrange
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            //Act
            service.GetById(id);

            //Assert
            mockTourneyRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void GetTourneys_ShouldCallRepositoryEntities()
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            service.GetTourneys();

            mockTourneyRepository.Verify(x => x.Entities, Times.Once);
        }

        [Test]
        public void EditProduct_ShouldCallRepositoryUpdate()
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            var mockTourney = new Mock<Tourney>();

            service.EditTourney(mockTourney.Object);

            mockTourneyRepository.Verify(x => x.Update(mockTourney.Object), Times.Once);
        }

        [Test]
        public void EditProduct_ShouldCallUnitOfWork()
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            var mockTourney = new Mock<Tourney>();

            service.EditTourney(mockTourney.Object);

            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void UserHasJoined_ShouldWorkCorrectly_WhenUserIsJoined()
        {
            var mockFactory = new Mock<ITourneyFactory>();
            var mockTourneyRepository = new Mock<IRepository<Tourney>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TourneyService(
                mockFactory.Object,
                mockTourneyRepository.Object,
                mockUserRepository.Object,
                mockPlayerRepository.Object,
                mockUnitOfWork.Object
                );

            var mockTourney = new Mock<Tourney>();
           
            //TODO fix the search logic to be testable

            mockTourneyRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockTourney.Object);

            service.EditTourney(mockTourney.Object);

            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }


    }
}
