﻿using BeerPong.Models;

namespace BeerPong.Factories
{
    public interface ITourneyFactory
    {
        Tourney CreateTourney(string name);

        Player CreatePlayer(Tourney tourney, User user);
    }
}
