namespace CianParser.QueryBuilder.Models
{
    public class SortBy
    {
        public const string PriceFromSmallToLarge = "price_object_order";
       
        public const string PriceFromLargeToSmall = "total_price_desc";
       
        public const string PriceSquareFirstChipper = "price_square_order";
       
        public const string PriceSquareFirstExpensive = "price_square_order_desc";
       
        public const string AreaOrder = "area_order";
       
        public const string StreetName = "street_name";
       
        public const string WalkingTimeToMetro = "walking_time";
       
        public const string FirstNewByDate = "creation_date_desc";
       
        public const string FirstOldByDate = "creation_date_asc";
    }
}