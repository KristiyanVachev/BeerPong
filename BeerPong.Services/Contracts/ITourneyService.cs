using System.Collections.Generic;
using BeerPong.Models;

namespace BeerPong.Services.Contracts
{
    public interface ITourneyService
    {
        Tourney CreateTourney(string name);

        Tourney GetById(int id);

        IEnumerable<Tourney> GetTourneys();

        void EditTourney(Tourney tourney);

        void DeleteTourney(int tourneyId);

        void JoinTourney(int tourneyId, string userId);
    }
}
