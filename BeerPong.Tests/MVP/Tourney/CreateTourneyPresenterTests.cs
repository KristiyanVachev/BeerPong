using System;
using BeerPong.MVP.Tourney.Create;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.MVP.Tourney
{
    [TestFixture]
    public class CreateTourneyPresenterTests
    {
        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICreateTourneyView>();

            Assert.Throws<ArgumentNullException>(() => new CreateTourneyPresenter(mockedView.Object, null));
        }
    }
}
