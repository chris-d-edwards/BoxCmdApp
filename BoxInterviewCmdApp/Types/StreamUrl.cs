using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BoxInterviewCmdApp.Collections
{
    public partial class StreamUrl
    {
        [JsonProperty("chunk_size")]
        public long ChunkSize { get; set; }

        [JsonProperty("entries")]
        public Entry[] Entries { get; set; }
    }

    public partial class Entry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("ttl")]
        public string Ttl { get; set; }

        [JsonProperty("max_retries")]
        public string MaxRetries { get; set; }

        [JsonProperty("retry_timeout")]
        public long RetryTimeout { get; set; }
    }

    public partial class StreamUrl
    {
        public static StreamUrl FromJson(string json) => JsonConvert.DeserializeObject<StreamUrl>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this StreamUrl self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
