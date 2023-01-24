using Identity.Core.Entities;
using Identity.Infrastructure.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Data
{
    public class AppDataContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();

        #region DbSets
        //public DbSet<User>? Users { get; set; }
        //public DbSet<UserClaim>? UserClaims { get; set; }
        //public DbSet<UserRole>? UserRoles { get; set; }
        //public DbSet<UserToken>? UserTokens { get; set; }
        //public DbSet<Role>? Roles { get; set; }
        //public DbSet<Person>? Persons { get; set; }
        //public DbSet<DataSource>? DataSources { get; set; }
        //public DbSet<Claim>? Claims { get; set; }
        //public DbSet<BrancheIp>? BranchIps { get; set; }
        //public DbSet<Branche>? Branches { get; set; }
        //public DbSet<Application>? Applications { get; set; }
        //public DbSet<RoleClaims>? RoleClaims { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserToken>().ToTable("UserTokens");
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new DataSourceMap());
            modelBuilder.ApplyConfiguration(new BranchMap());
            modelBuilder.ApplyConfiguration(new BranchIpMap());
            modelBuilder.ApplyConfiguration(new UserCompanyAccessMap());
            //modelBuilder.ApplyConfiguration(new ApplicationMap());

            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new UserCompanyAccessMap());
            //modelBuilder.ApplyConfiguration(new BranchMap());
            //modelBuilder.ApplyConfiguration(new BranchIpMap());
            //modelBuilder.ApplyConfiguration(new ClaimMap());
            //modelBuilder.ApplyConfiguration(new DataSourceMap());
            //modelBuilder.ApplyConfiguration(new PersonMap());
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.ApplyConfiguration(new RoleMap());
            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            //modelBuilder.ApplyConfiguration(new UserClaimMap());
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            //modelBuilder.ApplyConfiguration(new UserRoleMap());
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            ////modelBuilder.ApplyConfiguration(new UserTokenMap());
            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            //modelBuilder.ApplyConfiguration(new RoleClaimsMap());
            //modelBuilder.ApplyConfiguration(new ApplicationMap());
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");


        }
    }
}
