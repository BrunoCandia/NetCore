using Microsoft.EntityFrameworkCore;
using NetCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetCore2.Helpers.Interfaces;

namespace NetCore2
{
    public class NBAContext : DbContext
    {
        private readonly IUserService userService;

        public NBAContext(DbContextOptions<NBAContext> options, IUserService userService) : base(options)
        {
            this.userService = userService;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            //SaveProcessWithAbstractClass();
            SaveProcessWithInterface();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SaveProcessWithAbstractClass()
        {
            var currentTime = DateTimeOffset.UtcNow;
            var currentUser = this.userService.GetCurrentUser();

            foreach (var item in ChangeTracker.Entries().Where(entity => entity.State == EntityState.Added && entity.Entity is Entity))
            {                
                var entity = item.Entity as Entity;

                entity.CreatedDate = currentTime;
                entity.CreatedBy = currentUser.Identity.Name;
                entity.UpdatedDate = currentTime;
                entity.UpdatedBy = currentUser.Identity.Name;
            }

            foreach (var item in ChangeTracker.Entries().Where(entity => entity.State == EntityState.Modified && entity.Entity is Entity))
            {                
                var entity = item.Entity as Entity;
                
                entity.UpdatedDate = currentTime;
                entity.UpdatedBy = currentUser.Identity.Name;

                item.Property(nameof(entity.CreatedDate)).IsModified = false;
                item.Property(nameof(entity.UpdatedDate)).IsModified = false;
            }
        }

        private void SaveProcessWithInterface()
        {
            var currentTime = DateTimeOffset.UtcNow;
            var currentUser = this.userService.GetCurrentUser();

            foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    // implementation may change based on the useage scenario, this
                    // sample is for forma authentication.
                    //string currentUser = HttpContext.Current.User.Identity.Name;

                    // modify updated date and updated by column for 
                    // adds of updates.
                    auditableEntity.Entity.UpdatedDate = currentTime; //DateTime.Now;
                    auditableEntity.Entity.UpdatedBy = currentUser.Identity.Name;

                    // pupulate created date and created by columns for
                    // newly added record.
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = currentTime; //DateTime.Now;
                        auditableEntity.Entity.CreatedBy = currentUser.Identity.Name;
                    }
                    else
                    {
                        // we also want to make sure that code is not inadvertly
                        // modifying created date and created by columns 
                        auditableEntity.Property(p => p.CreatedDate).IsModified = false;
                        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
            }
        }
    }
}
