using System.Collections.Generic;

namespace CianParser.Parser.Models
{
    public class User
    {
        public string? AccountType { get; set; }
        
        public string? CianUserId { get; set; }
        
        public bool? IsAgent { get; set; }
        
        public bool? IsBuilder { get; set; }
        
        public IList<IDictionary<string, string>>? PhoneNumbers { get; set; }
        
    }
}