﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace UltimatR
{
    public abstract class EntityTypeMapping<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        protected ModelBuilder modelBuilder;

        public virtual void SetBuilder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public abstract void Configure(EntityTypeBuilder<TEntity> builder);
    }

    public static class DbModelBuilderExtensions
    {
        public static ModelBuilder ApplyIdentity<TContext>(this ModelBuilder builder)
        {
            foreach (var type in builder.Model.GetEntityTypes().ToList())
            {
                var clr = type.ClrType;
                if (clr != null && clr.GetInterfaces().Contains(typeof(IEntity)))
                {
                    var model = builder.Entity(type.ClrType);
                    model.HasKey("Id");
                    model.HasIndex("Ordinal");
                    model.Property("Ordinal").UseIdentityColumn();
                    model.Property("SSN")/*.HasColumnType("bytea").HasMaxLength(32)*/.IsConcurrencyToken(true);
                }
            }
            return builder;
        }

        public static ModelBuilder ApplyMapping<TEntity>(
            this ModelBuilder builder,
            EntityTypeMapping<TEntity> entityBuilder
        ) where TEntity : class
        {
            entityBuilder.SetBuilder(builder);
            builder.ApplyConfiguration(entityBuilder);
            return builder;
        }

        public static ModelBuilder ApplyIdentifiers<TEntity>(this ModelBuilder builder)
            where TEntity : Entity
        {
            return new IdentifiersMapping<TEntity>(builder).Configure();
        }

        public static ModelBuilder LinkSetToSet<TLeft, TRight>(
            this ModelBuilder builder,
            ExpandSite expandSite = ExpandSite.None,
            bool autoinclude = false,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboSetToSetRelation<TLeft, TRight>(
                builder,
                expandSite,
                dbSchema
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkSetToSet<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string rightName,
            ExpandSite expandSite = ExpandSite.None,
            bool autoinclude = false,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboSetToSetRelation<TLeft, TRight>(
                builder,
                leftName,
                rightName,
                expandSite,
                dbSchema
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkSetToSet<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string leftTableName,
            string rightName,
            string rightTableName,
            ExpandSite expandSite = ExpandSite.None,
            bool autoinclude = false,
            string parentSchema = null,
            string childSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboSetToSetRelation<TLeft, TRight>(
                builder,
                leftName,
                leftTableName,
                rightName,
                rightTableName,
                expandSite,
                parentSchema,
                childSchema
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkSetToRemoteSet<TLeft, TRight>(
            this ModelBuilder builder,
            ExpandSite expandSite = ExpandSite.None,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboSetToDsoSetRelation<TLeft, TRight>(
                builder,
                expandSite,
                dbSchema
            ).Configure();
        }

        public static ModelBuilder LinkSetToRemoteSet<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string rightName,
            ExpandSite expandSite = ExpandSite.None,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboSetToDsoSetRelation<TLeft, TRight>(
                builder,
                leftName,
                rightName,
                expandSite,
                dbSchema
            ).Configure();
        }

        public static ModelBuilder LinkSetToRemoteSet<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string leftTableName,
            string rightName,
            string rightTableName,
            ExpandSite expandSite = ExpandSite.None,
            string parentSchema = null,
            string childSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboSetToDsoSetRelation<TLeft, TRight>(
                builder,
                leftName,
                leftTableName,
                rightName,
                rightTableName,
                expandSite,
                parentSchema,
                childSchema
            ).Configure();
        }

        public static ModelBuilder LinkToSet<TLeft, TRight>(
            this ModelBuilder builder,
            ExpandSite expandSite = ExpandSite.None,
              bool autoinclude = false,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboToSetRelation<TLeft, TRight>(builder, expandSite).Configure(autoinclude);
        }

        public static ModelBuilder LinkToSet<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string rightName,
            ExpandSite expandSite = ExpandSite.None,
              bool autoinclude = false,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboToSetRelation<TLeft, TRight>(
                builder,
                leftName,
                rightName,
                expandSite,
                dbSchema
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkToSet<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string leftTableName,
            string rightName,
            string rightTableName,
            ExpandSite expandSite = ExpandSite.None,
              bool autoinclude = false,
            string parentSchema = null,
            string childSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboToSetRelation<TLeft, TRight>(
                builder,
                leftName,
                leftTableName,
                rightName,
                rightTableName,
                expandSite
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkToSingle<TLeft, TRight>(
            this ModelBuilder builder,
            ExpandSite expandSite = ExpandSite.None,
            bool autoinclude = false,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboToSingleRelation<TLeft, TRight>(
                builder,
                expandSite,
                dbSchema
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkToSingle<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string rightName,
            ExpandSite expandSite = ExpandSite.None,
               bool autoinclude = false,
            string dbSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboToSingleRelation<TLeft, TRight>(
                builder,
                leftName,
                rightName,
                expandSite,
                dbSchema
            ).Configure(autoinclude);
        }

        public static ModelBuilder LinkToSingle<TLeft, TRight>(
            this ModelBuilder builder,
            string leftName,
            string leftTableName,
            string rightName,
            string rightTableName,
            ExpandSite expandSite = ExpandSite.None,
               bool autoinclude = false,
            string parentSchema = null,
            string childSchema = null
        )
            where TLeft : Entity
            where TRight : Entity
        {
            return new DboToSingleRelation<TLeft, TRight>(
                builder,
                leftName,
                leftTableName,
                rightName,
                rightTableName,
                expandSite,
                parentSchema,
                childSchema
            ).Configure(autoinclude);
        }
    }
}
