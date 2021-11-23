using CianParser.QueryBuilder.Exceptions;

namespace CianParser.QueryBuilder.Builders
{
    public class PartFlatQueryBuilder : BaseQueryBuilder<PartFlatQueryBuilder>
    {
        private string[] _partType = { "room8=1", "room0=1" }; // [room8] Доля [room0] Комната
        
        protected override string OfferType => "&offer_type=flat";
        
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
            base.Build();
            
            if(Uri == null)
                throw new UriEmptyException();

            return Uri += '&' + string.Join('&', _partType);
        }
    }
}