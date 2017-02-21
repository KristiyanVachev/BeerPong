using BeerPong.Models;
using Moq;
using NUnit.Framework;

namespace BeerPong.Tests.Models
{
    [TestFixture]
    public class TourneyTests
    {
        [TestCase("Tourney")]
        [TestCase("Pong at the Gong")]
        public void Constructor_ShouldSetName_Correctly(string name)
        {
            var mockUser = new Mock<User>();

            var category = new Tourney(name, mockUser.Object);

            Assert.AreSame(category.Name, name);
        }
    }
}
