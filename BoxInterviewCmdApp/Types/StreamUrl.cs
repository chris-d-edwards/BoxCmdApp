using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BoxInterviewCmdApp.Types
{
    public class StreamEntry
    {
        public string type { get; set; }
        public string url { get; set; }
        public string ttl { get; set; }
        public string max_retries { get; set; }
        public int retry_timeout { get; set; }
    }

    public class StreamUrl
    {
        public int chunk_size { get; set; }
        public List<StreamEntry> entries { get; set; }
    }
}
