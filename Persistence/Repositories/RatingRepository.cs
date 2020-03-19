using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly StarWarsDbContext _starWarsDbContext;

        public RatingRepository(StarWarsDbContext starWarsDbContext)
        {
            this._starWarsDbContext = starWarsDbContext;
        }

        public void Add(int charId, int score)
        {
            Rating toAdd = new Rating
            {
                CharId = charId,
                Score = score
            };

            _starWarsDbContext.Add(toAdd);
            _starWarsDbContext.SaveChanges();
        }

        public List<Rating> GetRatingsByCharacterId(int charId)
        {
            return _starWarsDbContext.Ratings.Where(x => x.CharId == charId).ToList();
        }
    }
}
