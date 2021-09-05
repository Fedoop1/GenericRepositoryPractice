using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Sample.Model
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Country>().ToTable("Country");
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x =>
                x.Entity is IAuditableEntity && x.State == EntityState.Modified || x.State is EntityState.Added);

            foreach (var entry in modifiedEntries)
            {
                if(entry.Entity is IAuditableEntity auditableEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        auditableEntity.CreatedBy = Thread.CurrentPrincipal?.Identity.Name;
                        auditableEntity.CreatedTime = DateTime.Now;
                    }
                    else
                    {
                        base.Entry(auditableEntity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(auditableEntity).Property(x => x.CreatedTime).IsModified = false;
                    }

                    auditableEntity.UpdatedBy = Thread.CurrentPrincipal?.Identity.Name;
                    auditableEntity.UpdatedTime = DateTime.Now;
                }
                
            }

            return base.SaveChanges();
        }
    }
}
