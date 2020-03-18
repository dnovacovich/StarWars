using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        /// <summary>
        /// Agrega un registro Rating
        /// </summary>
        /// <param name="charId"></param>
        /// <param name="score"></param>
        void Add(int charId, int score);

        /// <summary>
        /// Obtiene un listado de Ratings según el identificador del personaje
        /// </summary>
        /// <param name="charId"></param>
        /// <returns></returns>
        List<Rating> GetRatingsByCharacterId(int charId);
    }
}
