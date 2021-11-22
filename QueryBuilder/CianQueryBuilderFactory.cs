using CianParser.QueryBuilder.Builders;

namespace CianParser.QueryBuilder
{
    public class CianQueryBuilderFactory
    {
        public static FlatQueryBuilder ForFlat()
        {
            return new FlatQueryBuilder();
        }
    }
}