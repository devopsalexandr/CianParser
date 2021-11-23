using System.Collections.Generic;

namespace CianParser.Parser.Models
{
    public class Building
    {
        public string? MaterialType { get; set; }
        
        public int? FloorsCount { get; set; }
        
        public int? BuildYear { get; set; }
        
        public BuildingDeadline? Deadline { get; set; }
        
        public int? PassengerLiftsCount { get; set; }
    }
}