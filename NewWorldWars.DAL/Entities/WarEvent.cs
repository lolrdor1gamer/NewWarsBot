using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NewWorldWars.DAL
{
    public class WarEvent : Entity
    {
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public byte RequiredLevel { get; set; }
    }
}
