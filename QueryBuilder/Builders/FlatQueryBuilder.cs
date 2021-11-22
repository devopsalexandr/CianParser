namespace CianParser.QueryBuilder.Builders
{
    public class FlatQueryBuilder
    {
        private const string host = "https://www.cian.ru/";
        
        private const string cat = "cat.php?";

        private const string engineVersion = "&engine_version=2";

        private string DealType { get; set; } = "deal_type=sale";

        private const string offerType = "&offer_type=flat";

        private string Region { get; set; }
        
        private string Sort { get; set; }
        
        private string Rooms { get; set; }
        
        private string Studios { get; set; }
        
        private string FreeLayout { get; set; }

        private string CurrentPage { get; set; } = "&p=1";

        private string Uri { get; set; }

    }
}