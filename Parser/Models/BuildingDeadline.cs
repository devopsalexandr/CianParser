namespace CianParser.Parser.Models
{
    public class BuildingDeadline
    {
        public int? Year { get; set; }
        
        public bool? IsComplete { get; set; }
        
        public string? QuarterEnd { get; set; }
        
        public string? Quarter { get; set; }
    }
}