using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Domain.Entities;
using Domain.Entities.ExternalApi;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class CharacterManager
    {
        #region Field's
        private readonly RequestExternalApiHelper _requestExternalApiHelper;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMemoryCache _memoryCache;
        #endregion

        #region Constructor
        public CharacterManager(RequestExternalApiHelper requestExternalApiHelper, IRatingRepository ratingRepository, IMemoryCache memoryCache)
        {
            this._requestExternalApiHelper = requestExternalApiHelper;
            this._ratingRepository = ratingRepository;
            this._memoryCache = memoryCache;
        } 
        #endregion

        #region Public Method's
        /// <summary>
        /// Retorna un personaje a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Character> SearchCharacter(int id)
        {
            Character result;

            CharacterApi characterApi;
            PlanetApi planetApi;
            SpeciesApi speciesApi;

            this.searchCharacterWithCache(id, out characterApi);

            if (characterApi == null)
                throw new CharacterNotFoundException("No se encontró el personaje solicitado");


            this.searchPlanetWithCache(characterApi.homeworld, out planetApi);
            this.searchSpeciesWithCache(characterApi.species.FirstOrDefault(), out speciesApi);

            List<Rating> ratings = _ratingRepository.GetRatingsByCharacterId(id);

            result = CharacterMapper.Map(characterApi, planetApi, speciesApi, ratings);

            return await Task.FromResult(result);
        }
      
        /// <summary>
        /// Agrega la puntación de un personaje
        /// </summary>
        /// <param name="charId"></param>
        /// <param name="score"></param>
        public void RateCharacter(int charId, int score)
        {
            if (!(score >= 1 && score <= 5))
            {
                throw new ScoreOutOfRangeException("La puntuación debe ser un número del 1 al 5");
            }

            _ratingRepository.Add(charId, score);
        }

        #endregion


        #region Private Method's
        /// <summary>
        /// Busca un personaje en una API según su ID. (Y se utiliza Cache)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterApi"></param>
        private void searchCharacterWithCache(int id, out CharacterApi characterApi)
        {
            if (!_memoryCache.TryGetValue("Character" + id.ToString(), out characterApi))
            {
                characterApi = _requestExternalApiHelper.searchCharacter(id);
                _memoryCache.Set("Character" + id.ToString(), characterApi);
            }
        }

        /// <summary>
        /// Busca un planeta en una API según su url. (Y se utiliza Cache)
        /// </summary>
        /// <param name="homeworld"></param>
        /// <param name="planetApi"></param>
        private void searchPlanetWithCache(string url, out PlanetApi planetApi)
        {
            if (!_memoryCache.TryGetValue(url, out planetApi))
            {
                planetApi = _requestExternalApiHelper.searchPlanet(url);
                _memoryCache.Set(url, planetApi);
            }
        }


        /// <summary>
        /// Busca una especie en una API según su url. (Y se utiliza Cache)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="speciesApi"></param>
        private void searchSpeciesWithCache(string url, out SpeciesApi speciesApi)
        {
            if (!_memoryCache.TryGetValue(url, out speciesApi))
            {
                speciesApi = _requestExternalApiHelper.searchSpecies(url);
                _memoryCache.Set(url, speciesApi);
            }
        } 
        #endregion
    }
}
