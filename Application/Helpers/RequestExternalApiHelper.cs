using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.ExternalApi;
using Application.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Application.Helpers
{
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
        public CharacterApi searchCharacter(int id)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(_appConfig["ExternalServicesURL:Character"] + id.ToString(), "", "GET", "application/json; charset=utf-8");
            CharacterApi characterApi = deserializeResult<CharacterApi>(responseApiEnvios);

            return characterApi;
        }

        public CharacterApi searchCharacter(string url)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(url, "", "GET", "application/json; charset=utf-8");
            CharacterApi characterApi = deserializeResult<CharacterApi>(responseApiEnvios);

            return characterApi;
        }

        public PlanetApi searchPlanet(int id)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(_appConfig["ExternalServicesURL:Planet"] + id.ToString(), "", "GET", "application/json; charset=utf-8");
            PlanetApi characterApi = deserializeResult<PlanetApi>(responseApiEnvios);

            return characterApi;
        }

        public PlanetApi searchPlanet(string url)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(url, "", "GET", "application/json; charset=utf-8");
            PlanetApi characterApi = deserializeResult<PlanetApi>(responseApiEnvios);

            return characterApi;
        }

        public SpeciesApi searchSpecies(int id)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(_appConfig["ExternalServicesURL:Species"] + id.ToString(), "", "GET", "application/json; charset=utf-8");
            SpeciesApi characterApi = deserializeResult<SpeciesApi>(responseApiEnvios);

            return characterApi;
        }

        public SpeciesApi searchSpecies(string url)
        {
            string responseApiEnvios = ApiHelper.MakeJsonRequest(url, "", "GET", "application/json; charset=utf-8");
            SpeciesApi characterApi = deserializeResult<SpeciesApi>(responseApiEnvios);

            return characterApi;
        }
        #endregion


        #region Private Method's
        private T deserializeResult<T>(string result)
        {
            return JsonConvert.DeserializeObject<T>(result);
        } 
        #endregion
    }
}
