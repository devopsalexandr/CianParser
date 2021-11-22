using System.Collections.Generic;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public abstract class BaseQueryBuilder
    {
        protected const string host = "https://www.cian.ru/";
        
        protected const string cat = "cat.php?";

        protected const string engineVersion = "&engine_version=2";
        
        protected string Sort { get; set; }

        protected string Region { get; set; }

        protected string DealType { get; set; } = "deal_type=sale";
        
        protected string CurrentPage { get; set; } = "&p=1";

        protected string Uri { get; set; }
        
        public abstract IList<string> BuildByPageRange(int start, int end);

        public abstract string Build();
    }
}