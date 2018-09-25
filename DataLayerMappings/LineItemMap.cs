﻿using System.Data.Entity.ModelConfiguration;
using Taha.Domains;

namespace Taha.DataLayerMappings
{
    public class LineItemMap : EntityTypeConfiguration<LineItem>
    {
        public LineItemMap()
        {
            //not mapped to database
            Ignore(t => t.LineTotal);
        }
    }
}
