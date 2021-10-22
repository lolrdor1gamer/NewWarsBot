using System;
using System.Collections.Generic;
using System.Text;

namespace NewWorldWars.DAL.Entities
{
    class Group : Entity
    {
        public byte First { get; set; }
        public byte Second { get; set; }
        public byte Third { get; set; }
        public byte Fours { get; set; }
        public byte Fifth { get; set; }
        public byte GroupState { get; set; }
    }
}
