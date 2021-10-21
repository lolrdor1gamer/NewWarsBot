using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWorldWars
{
    public struct WarConfigJson
    {
        [JsonProperty("reqlvl")]
        public string Level { get; private set; }

        [JsonProperty("reqpeople")]
        public string NumberOfPeople { get; private set; }
    }
}
