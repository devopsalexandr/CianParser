using System.Collections.Generic;

namespace CianParser.Parser.Models
{
    public class Building
    {
        public string? MaterialType { get; set; }
        
        public int? FloorsCount { get; set; }
        
        public int? buildYear { get; set; }
        
        public IList<IDictionary<string, string>>? deadline { get; set; }
        
        public int? passengerLiftsCount { get; set; }
    }
}