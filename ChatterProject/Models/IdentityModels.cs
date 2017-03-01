using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using static ChatterProject.Models.Content;

namespace ChatterProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Content> Content { get; set; }

        //public class MyEntities : DbContext
        //{
        //    public DbSet<User> Users { get; set; }

        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<User>()
        //        .HasMany(m => m.Followers)
        //        .WithMany(m => m.Following)
        //        .Map(x => x.MapLeftKey("UserId")
        //        .MapRightKey("FollowerId")
        //        .ToTable("UserFollowers"));

        //        //modelBuilder.Entity<User>()
        //        //    .HasMany(x => x.Followers).WithMany(x => x.Following)
        //        //    .Map(x => x.ToTable("Followers")
        //        //        .MapLeftKey("UserId")
        //        //        .MapRightKey("FollowerId"));
        //    }
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ChatterProject.Models.Content> Contents { get; set; }
    }
}