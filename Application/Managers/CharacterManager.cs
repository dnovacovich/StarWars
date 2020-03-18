using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Domain.Entities;
using Domain.Entities.ExternalApi;
using System.Collections.Generic;
using System.Linq;

namespace Application.Managers
{
    public class CharacterManager
    {
        #region Field's
        private readonly RequestExternalApiHelper _requestExternalApiHelper;
        private readonly IRatingRepository _ratingRepository;
        #endregion

        #region Constructor
        public CharacterManager(RequestExternalApiHelper requestExternalApiHelper, IRatingRepository ratingRepository)
        {
            this._requestExternalApiHelper = requestExternalApiHelper;
            this._ratingRepository = ratingRepository;
        } 
        #endregion

        #region Public Method's
        /// <summary>
        /// Retorna un personaje a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Character SearchCharacter(int id)
        {
            Character result;

            CharacterApi characterApi = _requestExternalApiHelper.searchCharacter(id);

            if (characterApi == null)
                throw new CharacterNotFoundException("No se encontró el personaje solicitado");

            PlanetApi planetApi = _requestExternalApiHelper.searchPlanet(characterApi.homeworld);
            SpeciesApi speciesApi = _requestExternalApiHelper.searchSpecies(characterApi.species.FirstOrDefault());
            List<Rating> ratings = _ratingRepository.GetRatingsByCharacterId(id);

            result = CharacterMapper.Map(characterApi, planetApi, speciesApi, ratings);

            return result;
        } 

        /// <summary>
        /// Agrega la puntación de un personaje
        /// </summary>
        /// <param name="charId"></param>
        /// <param name="score"></param>
        public void RateCharacter(int charId, int score)
        {
            _ratingRepository.Add(charId, score);
        }

        #endregion
    }
}
