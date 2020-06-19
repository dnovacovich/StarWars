using Domain.Entities.ExternalApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ExternalAPIs
{
    /// <summary>
    /// Solicitudes a API de Starwars
    /// </summary>
    public interface ISwAPI
    {
        /// <summary>
        /// Busca un personaje en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CharacterApi searchCharacter(int id);

        /// <summary>
        /// Busca un personaje usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        CharacterApi searchCharacter(string url);


        /// <summary>
        /// Busca un planeta en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlanetApi searchPlanet(int id);
        /// <summary>
        /// Busca un planeta usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        PlanetApi searchPlanet(string url);

        /// <summary>
        /// Busca una especie en un servicio externo a partir del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SpeciesApi searchSpecies(int id);

        /// <summary>
        /// Busca una especie usando una URL especifica
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        SpeciesApi searchSpecies(string url);
    }
}
