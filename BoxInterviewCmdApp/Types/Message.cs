using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
namespace BoxInterviewCmdApp.Types
{
    

    public class Message
    {
        public int version { get; set; }
        public string message { get; set; }
    }
}
