using Domain.Entities;
using Domain.Entities.ExternalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Mappers
{
    public static class CharacterMapper
    {
        public static Character Map(CharacterApi characterApi, PlanetApi planetApi, SpeciesApi speciesApi, List<Rating> ratings)
        {
            Character result = new Character();

            result.name = characterApi.name;
            result.height = characterApi.height;
            result.mass = characterApi.mass;
            result.hair_color = characterApi.hair_color;
            result.skin_color = characterApi.skin_color;
            result.eye_color = characterApi.eye_color;
            result.birth_year = characterApi.birth_year;
            result.gender = characterApi.gender;
            result.homeworld = HomeWorldMapper.Map(planetApi);
            result.species_name = (speciesApi != null) ? speciesApi.name : "";

            if (ratings.Count() > 0)
            {
                result.max_rating = ratings.Max(x => x.Score).ToString();
                result.average_rating = Math.Round(ratings.Average(x => x.Score), 2).ToString();
            }
            

            return result;
        }

        
    }
}
