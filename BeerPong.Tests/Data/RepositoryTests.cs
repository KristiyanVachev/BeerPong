using System.Data.Entity;
using BeerPong.Data;
using BeerPong.Models;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.Data
{
    [TestFixture]
    public class RepositoryTests
    {
        [TestCase(4)]
        [TestCase(0)]
        public void GetById_ShouldCallSetFind_WhenCalled(int id)
        {
            //Arrange
            var setMock = new Mock<DbSet<Tourney>>();
            var dbContext = new Mock<DbContext>();
            dbContext.Setup(x => x.Set<Tourney>()).Returns(setMock.Object);
            var repository = new Repository<Tourney>(dbContext.Object);

            //Act
            repository.GetById(id);

            //Assert
            setMock.Verify(x => x.Find(id), Times.Once);
        }
    }
}
