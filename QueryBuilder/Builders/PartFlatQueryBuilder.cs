using System.Collections.Generic;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public class PartFlatQueryBuilder : BaseQueryBuilder
    {
        public PartFlatQueryBuilder SetRegion(Region cityRegion)
        {
            Region = "&region=" + (int) cityRegion;
            return this;
        }
        
        public PartFlatQueryBuilder SortBy(string sortBy)
        {
            Sort = "&sort=" + sortBy;
            return this;
        }
        
        public override IList<string> BuildByPageRange(int start, int end)
        {
            throw new System.NotImplementedException();
        }

        public override string Build()
        {
            throw new System.NotImplementedException();
        }
    }
}