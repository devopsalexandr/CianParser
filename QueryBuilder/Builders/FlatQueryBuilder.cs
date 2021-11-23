using System;
using System.Collections.Generic;
using CianParser.QueryBuilder.Exceptions;
using CianParser.QueryBuilder.Models;

namespace CianParser.QueryBuilder.Builders
{
    public class FlatQueryBuilder : BaseQueryBuilder<FlatQueryBuilder>
    {
        // protected OfferType = "&offer_type=flat";
        protected override string OfferType => "&offer_type=flat";

        private string? Rooms { get; set; }
        
        private string? Studios { get; set; }
        
        private string? FreeLayout { get; set; }

        public FlatQueryBuilder SetRooms(params int[] rooms)
        {
            var tempRooms = "";
            
            foreach (var room in rooms)
            {
                if (room > 0 && room < 6)
                {
                    tempRooms += $"&room{room}=1";
                }
            }

            Rooms = tempRooms;
            
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
        
        public override string Build()
        {
            base.Build();
            
            if (FreeLayout != null) Uri += FreeLayout;
            if (Studios != null) Uri += Studios;
            if (Rooms != null) Uri += Rooms;

            return Uri ?? throw new UriEmptyException();
        }
    }
}