using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BoxInterviewCmdApp
{
    public partial class StreamPosition
    {
        [JsonProperty("chunk_size")]
        public long ChunkSize { get; set; }

        [JsonProperty("next_stream_position")]
        public long NextStreamPosition { get; set; }

        [JsonProperty("entries")]
        public object[] Entries { get; set; }
    }

    public partial class StreamPosition
    {
        public static StreamPosition FromJson(string json) => JsonConvert.DeserializeObject<StreamPosition>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this StreamPosition self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
