using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;


namespace BoxInterviewCmdApp
{

    class BoxAppLibrary
    {
        private string authkey;
        private string baseurl = "https://api.box.com/2.0/events";
        private string streamurl;
        private long streamposition;

        public string AuthKey { get => authkey; set => authkey = value; }
        public string BaseUrl { get => baseurl; set => baseurl = value; }
        public string StreamUrl { get => streamurl; set => streamurl = value; }
        public long StreamPosition { get => streamposition; set => streamposition = value; }

        public void getStreamNextPosition()
        {

            var client = new RestClient(string.Format("{0}?stream_position=now ", baseurl));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", authkey);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK) { throw new Exception(); }
            var streamPosition = JsonConvert.DeserializeObject<Types.StreamPosition>(response.Content);
            streamposition = streamPosition.next_stream_position;
        }

        public void getStreamEventURL()
        {
            var client = new RestClient(string.Format("{0} ", baseurl));
            var request = new RestRequest(Method.OPTIONS);
            request.AddHeader("Authorization", authkey);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK) { throw new Exception(); }
            var streamUrl = JsonConvert.DeserializeObject<Types.StreamUrl>(response.Content);
            streamurl = streamUrl.entries[0].url; 
        }

        public bool getLongPoll()
        {
            var client = new RestClient(string.Format("{0}&stream_position={1}", streamurl, streamposition));
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK) { return false; }
            var msg = JsonConvert.DeserializeObject<Types.Message>(response.Content);

            if (msg == null )
            {
                return false;
            }
            if (msg.message == "new_change")
            {

                return true;
            }
            if (msg.message == "reconnect")
            {
                return false;
            }

            return false;
                 
        }

        public void getEventEntry()
        {
            var client = new RestClient(string.Format("{0}?stream_position={1} ", baseurl, streamposition));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", authkey);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK) { throw new Exception(); }
            var eventEntry = JsonConvert.DeserializeObject<Types.EventEntry>(response.Content);
            streamposition = eventEntry.next_stream_position;
            Console.WriteLine(response.Content);
        }


    }
}