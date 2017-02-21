using System;
using System.Data.Entity;
using BeerPong.Data;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.Data
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException__WhenDbContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidData()
        {
            var dbContext = new Mock<DbContext>();

            Assert.DoesNotThrow(() => new UnitOfWork(dbContext.Object));
        }

        [Test]
        public void Commit_ShouldCallDbContextSaveChanges()
        {
            var dbContext = new Mock<DbContext>();
            var unitOfWork = new UnitOfWork(dbContext.Object);

            unitOfWork.Commit();

            dbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
