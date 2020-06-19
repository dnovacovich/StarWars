using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.ExternalAPIs;
using Domain.Entities.ExternalApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.ExternalAPIs
{
    /// <summary>
    /// Solicitudes a API de Starwars
    /// </summary>
    public class SwAPI : ISwAPI
    {
        #region Field's
        private readonly IConfiguration _appConfig;
        #endregion

        #region Constructor
        public SwAPI(IConfiguration appConfig)
        {
            this._appConfig = appConfig;
        }
        #endregion


        #region Public Method's
        /// <summary>
        /// Busca un personaje en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CharacterApi searchCharacter(int id)
        {
            string response = ApiHelper.RunRequest(_appConfig["ExternalServicesURL:Character"] + id.ToString() + "/", "", "GET", "application/json; charset=utf-8");

            if (string.IsNullOrEmpty(response))
                throw new CharacterNotFoundException("No se encontró el personaje solicitado");

            CharacterApi characterApi = deserializeResult<CharacterApi>(response);

            return characterApi;
        }


        /// <summary>
        /// Busca un personaje usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public CharacterApi searchCharacter(string url)
        {
            string response = ApiHelper.RunRequest(url, "", "GET", "application/json; charset=utf-8");

            if (string.IsNullOrEmpty(response))
                throw new CharacterNotFoundException("No se encontró el personaje solicitado");

            CharacterApi characterApi = deserializeResult<CharacterApi>(response);

            return characterApi;
        }

        /// <summary>
        /// Busca un planeta en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlanetApi searchPlanet(int id)
        {
            string response = ApiHelper.RunRequest(_appConfig["ExternalServicesURL:Planet"] + id.ToString() + "/", "", "GET", "application/json; charset=utf-8");

            if (string.IsNullOrEmpty(response))
                return null;

            PlanetApi planetApi = deserializeResult<PlanetApi>(response);

            return planetApi;
        }


        /// <summary>
        /// Busca un planeta usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public PlanetApi searchPlanet(string url)
        {
            string response = ApiHelper.RunRequest(url, "", "GET", "application/json; charset=utf-8");

            if (string.IsNullOrEmpty(response))
                return null;

            PlanetApi planetApi = deserializeResult<PlanetApi>(response);

            return planetApi;
        }


        /// <summary>
        /// Busca una especie en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SpeciesApi searchSpecies(int id)
        {
            string response = ApiHelper.RunRequest(_appConfig["ExternalServicesURL:Species"] + id.ToString() + "/", "", "GET", "application/json; charset=utf-8");

            if (string.IsNullOrEmpty(response))
                return null;

            SpeciesApi speciesApi = deserializeResult<SpeciesApi>(response);

            return speciesApi;
        }


        /// <summary>
        /// Busca una especie usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public SpeciesApi searchSpecies(string url)
        {
            string response = ApiHelper.RunRequest(url, "", "GET", "application/json; charset=utf-8");
            SpeciesApi speciesApi = deserializeResult<SpeciesApi>(response);

            return speciesApi;
        }
        #endregion


        #region Private Method's
        /// <summary>
        /// Deserializador
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        private T deserializeResult<T>(string result)
        {
            return JsonConvert.DeserializeObject<T>(result);
        }
        #endregion
    }
}
