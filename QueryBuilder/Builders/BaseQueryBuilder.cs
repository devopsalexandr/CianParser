using System;
using System.Collections.Generic;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public abstract class BaseQueryBuilder<T> where T : class
    {
        protected const string Host = "https://www.cian.ru/";
        
        protected const string Cat = "cat.php?";

        protected const string EngineVersion = "&engine_version=2";

        protected abstract string OfferType { get; }

        protected string? Sort { get; set; }

        protected string? Region { get; set; }
        
        protected string? MaxPrice { get; set; }
        
        protected string? MinPrice { get; set; }

        protected string DealType { get; set; } = "deal_type=sale";
        
        protected string CurrentPage { get; set; } = "&p=1";

        protected string? Uri { get; set; }
        
        public T SetMaxPrice(int price)
        {
            MaxPrice = "&maxprice=" + price;
            return this as T ?? throw new InvalidOperationException();
        }
        
        public T SetMinPrice(int price)
        {
            MinPrice = "&minprice=" + price;
            return this as T ?? throw new InvalidOperationException();
        }
        
        public T Page(int p)
        {
            CurrentPage = "&p=" + p;
            return this as T ?? throw new InvalidOperationException();
        }
        
        public T SortBy(string sortBy)
        {
            Sort = "&sort=" + sortBy;
            return this as T ?? throw new InvalidOperationException();
        }
        
        public T SetRegion(Region cityRegion)
        {
            Region = "&region=" + (int) cityRegion;
            return this as T ?? throw new InvalidOperationException();
        }
        
        public T SetDealType(DealType type)
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
            
            return this as T ?? throw new InvalidOperationException();
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
            if (OfferType == null)
                throw new ArgumentNullException(nameof(OfferType));
            
            if (DealType == null)
                throw new ArgumentNullException(nameof(OfferType));
            
            Uri = Host + Cat + DealType + OfferType + EngineVersion;

            if (Region != null) Uri += Region;
            if (CurrentPage != null) Uri += CurrentPage;
            if (Sort != null) Uri += Sort;
            if (MaxPrice != null) Uri += MaxPrice;
            if (MinPrice != null) Uri += MinPrice;
            
            return Uri ?? throw new Exception("Empty Uri");
        }
    }
}