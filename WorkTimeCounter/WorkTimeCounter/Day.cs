using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WorkTimeCounter
{
    [Serializable]
    public class Day
    {
        [JsonProperty("dur")]
        public TimeSpan Duration;
        [JsonProperty("dat")]
        public DateTime Date;
    }
}
