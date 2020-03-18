using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Character
    {
        public Character()
        {

        }
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public HomeWorld homeworld { get; set; }
        public string species_name { get; set; }
        public string average_rating { get; set; }
        public string max_rating { get; set; }
    }
}
