using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace NewWorldWars.DAL
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public byte Level { get; set; }
        public byte AbilityLevel { get; set; }

        public Int64 Role { get; set; }
    }
}
