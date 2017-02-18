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
        private readonly IRepository<Tourney> productRepository;
        private readonly IUnitOfWork unitOfWork;

        public TourneyService(ITourneyFactory factory, 
            IRepository<Tourney> productRepository,
            IUnitOfWork unitOfWork)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null");
            }

            if (productRepository == null)
            {
                throw new ArgumentNullException("Repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null");
            }

            this.factory = factory;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public Tourney CreateTourney(string name)
        {
            var tourney = this.factory.CreateTourney(name);

            this.productRepository.Add(tourney);
            this.unitOfWork.Commit();

            return tourney;
        }

        public Tourney GetById(int id)
        {
            var tourney = this.productRepository.GetById(id);

            return tourney;
        }

        public IEnumerable<Tourney> GetTourneys()
        {
            return this.productRepository.Entities.ToList();
        }

        public void EditTourney(Tourney tourney)
        {
            this.productRepository.Update(tourney);
            this.unitOfWork.Commit();
        }

        public void DeleteTourney(int tourneyId)
        {
            var tourney = this.productRepository.GetById(tourneyId);

            if (tourney != null)
            {
                this.productRepository.Delete(tourney);
                this.unitOfWork.Commit();
            }
        }
    }
}
