using BeerPong.Models;
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
            var category = new Tourney(name);

            Assert.AreSame(category.Name, name);
        }
    }
}
