using System.Collections.Generic;
using System.Linq;
using BeerPong.Data.Contracts;
using BeerPong.Factories;
using BeerPong.Models;
using BeerPong.Services.Contracts;
using Bytes2you.Validation;

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
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(tourneyRepository, "tourneyRepository").IsNull().Throw();
            Guard.WhenArgument(userRepository, "userRepository").IsNull().Throw();
            Guard.WhenArgument(playeRepository, "playeRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.factory = factory;
            this.tourneyRepository = tourneyRepository;
            this.userRepository = userRepository;
            this.playerRepository = playeRepository;
            this.unitOfWork = unitOfWork;
        }

        public Tourney CreateTourney(string name, string userId)
        {
            var user = this.userRepository.GetById(userId);

            var tourney = this.factory.CreateTourney(name, user);

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

            var newPlayer = this.factory.CreatePlayer(tourney, user, user.Email);

            this.playerRepository.Add(newPlayer);
            
            this.unitOfWork.Commit();
        }

        public void LeaveTourney(int tourneyId, string userId)
        {
            //TODO: Create a playerRepository which removes a player by given userId and tourneyId
            var playerToRemove = playerRepository.Entities.FirstOrDefault(x => x.UserId == userId && x.TourneyId == tourneyId);

            playerRepository.Delete(playerToRemove);

            this.unitOfWork.Commit();
        }

        public bool UserHasJoined(int tourneyId, string userId)
        {
            var tourney = this.tourneyRepository.GetById(tourneyId);

            foreach (var player in tourney.Players)
            {
                if (player.UserId == userId)
                {
                    return true;
                }
            }

            return false;
        }

        public bool UserIsOwner(int tourneyId, string userId)
        {
            var tourney = this.tourneyRepository.GetById(tourneyId);

            if (tourney.OwnerId == userId)
            {
                return true;
            }

            return false;
        }
    }
}
