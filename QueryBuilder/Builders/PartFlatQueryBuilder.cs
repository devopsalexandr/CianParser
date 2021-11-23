using System;
using System.Collections.Generic;
using System.Linq;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public class PartFlatQueryBuilder : BaseQueryBuilder<PartFlatQueryBuilder>
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

        public override string Build()
        {
            Uri = Host + Cat + DealType + offerType + EngineVersion;

            if (Region != null) Uri += Region;
            if (CurrentPage != null) Uri += CurrentPage;
            if (Sort != null) Uri += Sort;

            Uri += '&' + String.Join('&', _partType);

            return Uri;
        }
    }
}