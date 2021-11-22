using System.Collections.Generic;
using CianParser.QueryBuilder.Models;

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
        
        public FlatQueryBuilder SetRegion(Region cityRegion)
        {
            Region = "&region=" + (int) cityRegion;
            return this;
        }
        
        public FlatQueryBuilder SortBy(string s)
        {
            Sort = "&sort=" + s;
            
            return this;
        }

        public FlatQueryBuilder SetRooms(params int[] rooms)
        {
            foreach (var room in rooms)
            {
                if (room > 0 && room < 6)
                {
                    Rooms = $"&room{room}=1";
                }
            }
            return this;
        }
        
        public FlatQueryBuilder IncludeStudios() // студии
        {
            Studios = "&room7=1";
            return this;
        }

        public FlatQueryBuilder IncludeFreeLayout() // свободная планировка
        {
            FreeLayout = "&room9=1";
            return this;
        }
        
        public FlatQueryBuilder Page(int p) // свободная планировка
        {
            CurrentPage = "&p=" + p;
            return this;
        }
        
        public FlatQueryBuilder SetDealType(DealType type)
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

        public virtual string Build()
        {
            Uri = host + cat + DealType + offerType + engineVersion;

            if (FreeLayout != null) Uri += FreeLayout;
            if (Studios != null) Uri += Studios;
            if (Rooms != null) Uri += Rooms;
            if (Region != null) Uri += Region;
            if (CurrentPage != null) Uri += CurrentPage;
            if (Sort != null) Uri += Sort;

            return Uri;
        }

    }
}