﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class AttributeMapping : EntityTypeMapping<Attribute>
    {
        const string TABLE_NAME = "Attributes";

        public override void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Key).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.Value).HasMaxLength(255).HasColumnType("varchar").IsRequired();

            modelBuilder
              .LinkSetToSet<Attribute, Attribute>(
                  nameof(Attribute.RelatedTo),
                  nameof(Attribute.RelatedFrom),
                  ExpandSite.OnRight
              );
        }
    }
}