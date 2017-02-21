using System.Collections.Generic;
using BeerPong.Models;

namespace BeerPong.Services.Contracts
{
    public interface ITourneyService
    {
        Tourney CreateTourney(string name, string userId);

        Tourney GetById(int id);

        IEnumerable<Tourney> GetTourneys();

        void EditTourney(Tourney tourney);

        void DeleteTourney(int tourneyId);

        void JoinTourney(int tourneyId, string userId);

        void LeaveTourney(int tourneyId, string userId);

        bool UserHasJoined(int tourneyId, string userId);

        bool UserIsOwner(int tourneyId, string userId);
    }
}
