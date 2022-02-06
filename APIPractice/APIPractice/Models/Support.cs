﻿using Newtonsoft.Json;

namespace APIPractice.Models
{
    public class Support
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
