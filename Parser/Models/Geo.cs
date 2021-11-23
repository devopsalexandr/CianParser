using System.Collections.Generic;

namespace CianParser.Parser.Models
{
    public class Geo
    {
        public IDictionary<string, string>? Coordinates { get; set; }

        public int? CountryId { get; set; }
    }
}