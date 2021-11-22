using System;
using System.Collections.Generic;
using System.Linq;
using CianParser.QueryBuilder.Models;
using CianParser.QueryBuilder.Models.SubUrban;

namespace CianParser.QueryBuilder.Builders
{
    public class SubUrbanQueryBuilder : BaseQueryBuilder
    {
        private const string offerType = "&offer_type=suburban";

        private string _objectType =
            "&object_type%5B0%5D=1&object_type%5B1%5D=2&object_type%5B2%5D=3&object_type%5B3%5D=4";

        private string OfferFilter { get; set; }
        
        public SubUrbanQueryBuilder SetObjectsType(params ObjectType[] types)
        {
            var objectTypes = types.Distinct();

            var enumerable = objectTypes as ObjectType[] ?? objectTypes.ToArray();
            
            if (enumerable.Count() <= 4)
            {
                var tempString = "";
                
                for (var i=0; i <= enumerable.Length - 1; i++)
                {
                    tempString += $"&object_type%5B{i}%5D=" + (int) enumerable[i];
                }

                _objectType = tempString;
                
                return this;
            }

            throw new Exception("There are a lot off types");
        }

        public SubUrbanQueryBuilder OfferFrom(OfferFilter filter)
        {
            OfferFilter = "&suburban_offer_filter=" + (int) filter;
            return this;
        }
        
        public SubUrbanQueryBuilder Page(int p)
        {
            CurrentPage = "&p=" + p;
            return this;
        }
        
        public SubUrbanQueryBuilder SortBy(string sortBy)
        {
            Sort = "&sort=" + sortBy;
            return this;
        }
        
        public SubUrbanQueryBuilder SetRegion(Region cityRegion)
        {
            Region = "&region=" + (int) cityRegion;
            return this;
        }
        
        public override IList<string> BuildByPageRange(int start, int end)
        {
            var listOfLinks = new List<string>();

            for (var i = start; i<=end; i++)
            {
                Page(i);
                listOfLinks.Add(Build());
            }
            return listOfLinks;
        }

        public override string Build()
        {
            Uri = host + cat + DealType + offerType + engineVersion + _objectType;

            if (Region != null) Uri += Region;
            if (CurrentPage != null) Uri += CurrentPage;
            if (Sort != null) Uri += Sort;

            return Uri;
        }
    }
}