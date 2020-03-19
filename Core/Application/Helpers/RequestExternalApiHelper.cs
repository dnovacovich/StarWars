using Domain.Entities.ExternalApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Helpers
{
    /// <summary>
    /// Solicitudes a API's externas
    /// </summary>
    public class RequestExternalApiHelper
    {
        #region Field's
        private readonly IConfiguration _appConfig;
        #endregion

        #region Constructor
        public RequestExternalApiHelper(IConfiguration appConfig)
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
            string responseApiEnvios = ApiHelper.MakeJsonRequest(_appConfig["ExternalServicesURL:Character"] + id.ToString(), "", "GET", "application/json; charset=utf-8");
            CharacterApi characterApi = deserializeResult<CharacterApi>(responseApiEnvios);

            return characterApi;
        }


        /// <summary>
        /// Busca un personaje usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public CharacterApi searchCharacter(string url)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(url, "", "GET", "application/json; charset=utf-8");
            CharacterApi characterApi = deserializeResult<CharacterApi>(responseApiEnvios);

            return characterApi;
        }

        /// <summary>
        /// Busca un planeta en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlanetApi searchPlanet(int id)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(_appConfig["ExternalServicesURL:Planet"] + id.ToString(), "", "GET", "application/json; charset=utf-8");
            PlanetApi characterApi = deserializeResult<PlanetApi>(responseApiEnvios);

            return characterApi;
        }


        /// <summary>
        /// Busca un planeta usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public PlanetApi searchPlanet(string url)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(url, "", "GET", "application/json; charset=utf-8");
            PlanetApi characterApi = deserializeResult<PlanetApi>(responseApiEnvios);

            return characterApi;
        }


        /// <summary>
        /// Busca una especie en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SpeciesApi searchSpecies(int id)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(_appConfig["ExternalServicesURL:Species"] + id.ToString(), "", "GET", "application/json; charset=utf-8");
            SpeciesApi characterApi = deserializeResult<SpeciesApi>(responseApiEnvios);

            return characterApi;
        }


        /// <summary>
        /// Busca una especie usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public SpeciesApi searchSpecies(string url)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(url, "", "GET", "application/json; charset=utf-8");
            SpeciesApi characterApi = deserializeResult<SpeciesApi>(responseApiEnvios);

            return characterApi;
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
