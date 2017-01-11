﻿using Nop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Autofac;
using Nop.Core;
using System.Data.Entity.Infrastructure;

namespace Nop.Plugin.Misc.PricePerStore.Data
{
    public class PricePerStoreObjectContext : DbContext, IDbContext
    {

        public PricePerStoreObjectContext(string connectionString): base(connectionString) { }

        public bool AutoDetectChangesEnabled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ProxyCreationEnabled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = default(int?), params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Configurations.Add( new ProductPriceFieldMap() );
            base.OnModelCreating( modelBuilder );
        }

        public void Install()
        {
            Database.SetInitializer<PricePerStoreObjectContext>(null);
            Database.ExecuteSqlCommand(CreateDatabaseInstallationScript());
            SaveChanges();
        }

        public void Uninstall()
        {
            this.DropPluginTable("PricePerStore_Product");
        }

        public string CreateDatabaseInstallationScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }
    }
}
