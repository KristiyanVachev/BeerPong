using System;
using System.Collections.Generic;
using System.Linq;
using BeerPong.Data.Contracts;
using BeerPong.Factories;
using BeerPong.Models;
using BeerPong.Services.Contracts;

namespace BeerPong.Services
{
    public class TourneyService : ITourneyService
    {
        //TODO make them properties
        private readonly ITourneyFactory factory;
        private readonly IRepository<Tourney> tourneyRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Player> playerRepository;
        private readonly IUnitOfWork unitOfWork;

        public TourneyService(ITourneyFactory factory,
            IRepository<Tourney> tourneyRepository,
            IRepository<User> userRepository,
            IRepository<Player> playeRepository,
            IUnitOfWork unitOfWork)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null");
            }

            if (tourneyRepository == null)
            {
                throw new ArgumentNullException("Repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null");
            }

            this.factory = factory;
            this.tourneyRepository = tourneyRepository;
            this.userRepository = userRepository;
            this.playerRepository = playeRepository;
            this.unitOfWork = unitOfWork;
        }

        public Tourney CreateTourney(string name)
        {
            var tourney = this.factory.CreateTourney(name);

            this.tourneyRepository.Add(tourney);
            this.unitOfWork.Commit();

            return tourney;
        }

        public Tourney GetById(int id)
        {
            var tourney = this.tourneyRepository.GetById(id);

            return tourney;
        }

        public IEnumerable<Tourney> GetTourneys()
        {
            return this.tourneyRepository.Entities.ToList();
        }

        public void EditTourney(Tourney tourney)
        {
            this.tourneyRepository.Update(tourney);
            this.unitOfWork.Commit();
        }

        public void DeleteTourney(int tourneyId)
        {
            var tourney = this.tourneyRepository.GetById(tourneyId);

            if (tourney != null)
            {
                this.tourneyRepository.Delete(tourney);
                this.unitOfWork.Commit();
            }
        }

        public void JoinTourney(int tourneyId, string userId)
        {
            var tourney = this.tourneyRepository.GetById(tourneyId);
            var user = this.userRepository.GetById(userId);

            var newPlayer = this.factory.CreatePlayer(tourney, user);

            this.playerRepository.Add(newPlayer);

            //tourney.Players.Add(/*username*/);
            //this.productRatingRepository.Add(newRating);
            this.unitOfWork.Commit();
        }
    }
}
