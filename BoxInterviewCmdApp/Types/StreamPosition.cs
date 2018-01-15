using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BoxInterviewCmdApp.Types
{
    public class StreamPosition
    {
        public int chunk_size { get; set; }
        public long next_stream_position { get; set; }
        public List<object> entries { get; set; }
    }


}
