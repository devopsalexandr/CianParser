using System.Collections.Generic;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public abstract class BaseQueryBuilder<T> : IQueryBuilder where T : IQueryBuilder
    {
        protected const string host = "https://www.cian.ru/";
        
        protected const string cat = "cat.php?";

        protected const string engineVersion = "&engine_version=2";
        
        protected string Sort { get; set; }

        protected string Region { get; set; }

        protected string DealType { get; set; } = "deal_type=sale";
        
        protected string CurrentPage { get; set; } = "&p=1";

        protected string Uri { get; set; }
        
        public abstract string Build();
        
        public T? Page(int p)
        {
            CurrentPage = "&p=" + p;
            return this as T;
        }
        
        public T? SortBy(string sortBy)
        {
            Sort = "&sort=" + sortBy;
            return this as T;
        }
        
        public T? SetRegion(Region cityRegion)
        {
            Region = "&region=" + (int) cityRegion;
            return this as T;
        }
        
        public T? SetDealType(DealType type)
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
            
            return this as T;
        }
        
        public virtual IList<string> BuildByPageRange(int start, int end)
        {
            var listOfLinks = new List<string>();

            for (var i = start; i<=end; i++)
            {
                Page(i);
                listOfLinks.Add(Build());
            }
            return listOfLinks;
        }
    }
}