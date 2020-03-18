using Domain.Entities;
using Domain.Entities.ExternalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Mappers
{
    public static class HomeWorldMapper
    {
        public static HomeWorld Map(PlanetApi planetApi)
        {
            HomeWorld result = new HomeWorld();

            if (planetApi != null)
            {
                result.name = planetApi.name;
                result.population = planetApi.population;
                result.known_residents_count = planetApi.residents.Count().ToString();
            }

            return result;
        }
    }
}
