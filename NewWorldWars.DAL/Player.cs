using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace NewWorldWars.DAL
{
    public abstract class Player
    {
        [Key]
        public int Id { get; set; }
    }
}
