using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Helpers;
using Application.Mappers;
using Domain.Entities;
using Domain.Entities.ExternalApi;

namespace Application.Managers
{
    public class CharacterManager
    {
        #region Field's
        private readonly RequestExternalApiHelper _requestExternalApiHelper; 
        #endregion

        public CharacterManager(RequestExternalApiHelper requestExternalApiHelper)
        {
            this._requestExternalApiHelper = requestExternalApiHelper;
        }

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

            result = CharacterMapper.Map(characterApi, planetApi, speciesApi);

            return result;
        } 


        public void RateCharacter(int id, int score)
        {

        }

        #endregion
    }
}
