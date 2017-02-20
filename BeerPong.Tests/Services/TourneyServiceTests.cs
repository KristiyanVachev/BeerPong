using BeerPong.Data.Contracts;
using BeerPong.Factories;
using BeerPong.Models;
using BeerPong.Services;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.Services
{
    [TestFixture]
    public class TourneyServiceTests
    {
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
    }
}
