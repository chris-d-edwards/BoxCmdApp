using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BoxInterviewCmdApp.Types
{
    public class CreatedBy
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
    }

    public class Entry2
    {
        public string type { get; set; }
        public string id { get; set; }
        public object sequence_id { get; set; }
        public object etag { get; set; }
        public string name { get; set; }
    }

    public class PathCollection
    {
        public int total_count { get; set; }
        public List<Entry2> entries { get; set; }
    }

    public class CreatedBy2
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
    }

    public class ModifiedBy
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
    }

    public class OwnedBy
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
    }

    public class Parent
    {
        public string type { get; set; }
        public string id { get; set; }
        public object sequence_id { get; set; }
        public object etag { get; set; }
        public string name { get; set; }
    }

    public class Source
    {
        public string type { get; set; }
        public string id { get; set; }
        public string sequence_id { get; set; }
        public string etag { get; set; }
        public string sha1 { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public PathCollection path_collection { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? modified_at { get; set; }
        public DateTime? trashed_at { get; set; }
        public object purged_at { get; set; }
        public DateTime? content_created_at { get; set; }
        public DateTime? content_modified_at { get; set; }
        public CreatedBy2 created_by { get; set; }
        public ModifiedBy modified_by { get; set; }
        public OwnedBy owned_by { get; set; }
        public object shared_link { get; set; }
        public Parent parent { get; set; }
        public string item_status { get; set; }
        public bool synced { get; set; }
    }

    public class Entry
    {
        public string type { get; set; }
        public string event_id { get; set; }
        public CreatedBy created_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? recorded_at { get; set; }
        public string event_type { get; set; }
        public string session_id { get; set; }
        public Source source { get; set; }
    }

    public class EventEntry
    {
        public int chunk_size { get; set; }
        public long next_stream_position { get; set; }
        public List<Entry> entries { get; set; }
    }

}
