using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces.Repositories
{
    interface IRatingRepository
    {
        void Add(int charId, int score);
        List<Rating> GetRatingsByCharacterId(int charId);
    }
}
