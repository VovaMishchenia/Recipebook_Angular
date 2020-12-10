using Microsoft.EntityFrameworkCore;
using RecipeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Core.Objects;

namespace RecipeBook.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
           
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<Friend> Friends { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.UserInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserInfo>(a => a.Id);
            
            //builder.Entity<RecipeUserInfo>()
            //.HasKey(t => new { t.RecipeId, t.UserInfoId });

            //builder.Entity<RecipeUserInfo>()
            //    .HasOne(sc => sc.Recipe)
            //    .WithMany(s => s.RecipeUserInfos)
            //    .HasForeignKey(sc => sc.RecipeId);

            //builder.Entity<RecipeUserInfo>()
            //    .HasOne(sc => sc.Recipe)
            //    .WithMany(c => c.RecipeUserInfos)
            //    .HasForeignKey(sc => sc.RecipeId);

            base.OnModelCreating(builder);
        }
        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries<Recipe>())
        //    {
        //        if (entry.State == EntityState.Modified)
        //        {
        //            // Get the changed values.
        //            var modifiedProps = ObjectStateManager.GetObjectStateEntry(entry.).GetModifiedProperties();
        //            var currentValues = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).CurrentValues;
        //            foreach (var propName in modifiedProps)
        //            {
        //                var newValue = currentValues[propName];
        //                //log changes
        //            }
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}
