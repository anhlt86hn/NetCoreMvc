using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreMvc.Domain;

namespace NetCoreMvc.WebApp
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppUser> AppUsers { set; get; }
        public DbSet<Command> Commands { set; get; }
        public DbSet<CommandInFunction> CommandInFunctions { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<Permission> Permissions { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<AppRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            //builder.Entity<AppUser>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<AppRole>().ToTable("AppRoles");
            builder.Entity<AppUser>().ToTable("AppUsers");
            builder.Entity<Permission>()
                       .HasKey(c => new { c.RoleId, c.FunctionId, c.CommandId });
            builder.Entity<CommandInFunction>()
                       .HasKey(c => new { c.CommandId, c.FunctionId });
            builder.HasSequence("NetCoreMvc");
        }
    }
}