using System;
using System.Collections.Generic;
using System.Linq;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public class PartFlatQueryBuilder : BaseQueryBuilder
    {
        private string[] _partType = { "room8=1", "room0=1" }; // [room8] Доля [room0] Комната
        
        private const string offerType = "&offer_type=flat";
        
        public PartFlatQueryBuilder OnlyRooms()
        {
            _partType[1] = "room8=0";
            return this;
        }
        
        public PartFlatQueryBuilder OnlyPartOfFlat()
        {
            _partType[0] = "room0=0";
            return this;
        }
        
        public PartFlatQueryBuilder SetRegion(Region cityRegion)
        {
            Region = "&region=" + (int) cityRegion;
            return this;
        }
        
        public PartFlatQueryBuilder SetDealType(DealType type)
        {
            switch (type)
            {
                case Models.DealType.Sale:
                    DealType = "&deal_type=sale";
                    break;
                
                case Models.DealType.Rent:
                    DealType = "&offer_type=rent&type=4";
                    break;
                
                case Models.DealType.RentByDay:
                    DealType = "&offer_type=rent&type=2";
                    break;
            }
            
            return this;
        }
        
        public PartFlatQueryBuilder Page(int p)
        {
            CurrentPage = "&p=" + p;
            return this;
        }
        
        public PartFlatQueryBuilder SortBy(string sortBy)
        {
            Sort = "&sort=" + sortBy;
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
            Uri = host + cat + DealType + offerType + engineVersion;

            if (Region != null) Uri += Region;
            if (CurrentPage != null) Uri += CurrentPage;
            if (Sort != null) Uri += Sort;

            Uri += '&' + String.Join('&', _partType);

            return Uri;
        }
    }
}