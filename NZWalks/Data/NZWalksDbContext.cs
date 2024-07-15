using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: IdentityDbContext<User,Role,Guid>
    {
       public DbSet<Region> Regions { get; set; } 
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

       // public DbSet<User> Users { get; set; }
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(iul => new { iul.LoginProvider, iul.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(iur => new { iur.UserId, iur.RoleId });
            modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });
            //modelBuilder.Entity<User_Role>()
            //    .HasOne(x => x.Role)
            //    .WithMany(y => y.UserRoles)
            //    .HasForeignKey(x => x.RoleId);

            //modelBuilder.Entity<User_Role>()
            //    .HasOne(x => x.User)
            //    .WithMany(y => y.UserRoles)
            //    .HasForeignKey(x => x.UserId);

        }

        
       // public DbSet<Role> Roles { get; set; }
        //public DbSet<User_Role> Users_Roles { get; set; }
    }
}
