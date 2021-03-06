using CianParser.QueryBuilder.Builders;

namespace CianParser.QueryBuilder
{
    public class CianQueryBuilderFactory
    {
        public static FlatQueryBuilder ForFlat()
        {
            return new FlatQueryBuilder();
        }
        
        public static PartFlatQueryBuilder ForPartOfFlat()
        {
            return new PartFlatQueryBuilder();
        }
        
        public static SuburbanQueryBuilder ForSubUrban()
        {
            return new SuburbanQueryBuilder();
        }
    }
}