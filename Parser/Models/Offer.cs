using System.Collections.Generic;

namespace CianParser.Parser.Models
{
    public class Offer
    {
        public string? Id { get; set; }
        
        public string? Added { get; set; }
        
        public string? AddedTimestamp { get; set; }
        
        public IList<int>? CategoriesIds { get; set; }
        
        public string? Description { get; set; }
        
        public string? FlatType { get; set; }
        
        public int? FloorNumber { get; set; }
        
        public bool? FromDeveloper { get; set; }
        
        public string? FullUrl { get; set; }
        
        public bool? IsApartments { get; set; }
        
        public string? JkUrl { get; set; }
        
        public IList<Photo>? Photos { get; set; }
        
        public string? Title { get; set; }
        
        public string? TotalArea { get; set; }
        
        public User? User { get; set; }
        
        public IList<Phone>? Phones { get; set; }
        
        public int? RoomsCount { get; set; }
        
        public string? LivingArea { get; set; }
        
        public int? LoggiasCount { get; set; }
        
        public string? KitchenArea { get; set; }
        
        public Geo? Geo { get; set; }
        
        public Building? Building { get; set; }
    }
}