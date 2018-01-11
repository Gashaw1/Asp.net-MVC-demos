using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleBooks.Models
{
    public class Items
    {
        string Kind { get; set; }
        string Id { get; set; }
        string SelfLink { get; set; }

        VolumeInfo volumeinfo { get; set; }
    }
    public class VolumeInfo
    {
        public string Title { get; set; }
        public Authors _Author { get; set; }
        public string Publisher { get; set; }
        public string PublisDate { get; set; }    
        public string Description { get; set; }   
    }
    public class Authors
    {
        public List<string> authors { get; set; }
    }
    public class IndustryIdentifier
    {
        public List<string> types { get; set; }
        public List<string> identifiers { get; set; }   
    }

}