using Microsoft.EntityFrameworkCore;
using Compression_Force.Domain.Entities;

namespace Compression_Force.Data;

public partial class ApplicationDbContext : DbContext
{
    // ❌ REMOVE parameterless constructor if possible
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

        // ✅ ADD BACK ALL DbSets THAT ARE USED ANYWHERE
        public DbSet<UserManagement> UserManagements { get; set; }
        public DbSet<Recipe> Recipes { get; set; }   // 🔥 FIX
        public DbSet<RecipeHistory> RecipeHistroys { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<GroupPrivilege> GroupPrivileges { get; set; }
        public DbSet<SecuritySettings> SecuritySettings { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
