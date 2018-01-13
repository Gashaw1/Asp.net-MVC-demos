using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleBooks.Models
{
    public class Result
    {
        string kind { get; set; }
        string TotlaItem { get; set; }
        public Items _Items { get; set; }
    }
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
        public List<Authors> _Author { get; set; }
        public string Publisher { get; set; }
        public string PublisDate { get; set; }
        public string Description { get; set; }
        public List<IndustryIdentifier> industryIdentifiers { get; set; }
        public ReadingModes _ReadingModes { get; set; }
        public int PageCount { get; set; }
        public string PrintType { get; set; }
        public List<Catagorie> Catagories { get; set; }
        public string MaturityRating { get; set; }
        public bool alowAnonLogging { get; set; }
        public string contentVersion { get; set; }
        public List<string> ImagesLinks { get; set; }
        public string Language { get; set; }
        public string PreviewLink { get; set; }
        public string InfoLink { get; set; }
        public string canonicalVolumeLink { get; set; }
        public SaleInfo _SaleInfo { get; set; }
        public AccessInfo _AccessIno { get; set; }
        public SearchInfo _serarchInfo { get; set; }

    }

    public class SearchInfo
    {
        public string textSnipet { get; set; }
    }

    public class AccessInfo
    {
        public string country { get; set; }
        public string ViewAbility { get; set; }
        public bool emeddable { get; set; }
        public bool publicDomain { get; set; }
        public string textToSpeechPermission { get; set; }
        public Epub epub { get; set; }
        public Pdf pdf { get; set; }
        public string ReaderLink { get; set; }
        public string AccessViewStatus { get; set; }
        public bool quteSharingAllowed { get; set; }

    }

    public class Pdf
    {
        public bool Isabaliable { get; set; }
    }

    public class Epub
    {
        public bool IsAvaliable { get; set; }
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
    public class ReadingModes
    {
        public bool text { get; set; }
        public bool image { get; set; }
    }
    public class Catagorie
    {
        public List<string> catagory { get; set; }
    }
    public class SaleInfo
    {
        public string country { get; set; }
        public string Saleability { get; set; }
        public bool IsEbook { get; set; }
    }

}