using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace ReactASPNetMVCDemo
{
    public class DemoContext : DbContext
    {
        public DbSet<ContactUs> ContactUs { get; set; }
        public DemoContext(IConnectionProvider connProvider): base(connProvider.ConnectionString)
        {

        }

        private void ApplyDefaultDates()
        {
            //default values for date created and modified
            var now = DateTime.Now;
            var entries = ChangeTracker.Entries<IAuditableEntity>();
            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Added)
                    entity.DateCreated = now;

                entity.DateModified = now;

            }

            ChangeTracker.DetectChanges();
        }

        public override int SaveChanges()
        {
            ApplyDefaultDates();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            ApplyDefaultDates();
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyDefaultDates();
            return base.SaveChangesAsync(cancellationToken);
        }

       
    }
}
