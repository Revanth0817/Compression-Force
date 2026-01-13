using Microsoft.EntityFrameworkCore;
using CompressionForce.Domain.Entities;

namespace CompressionForce.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<UserManagement> UserManagements { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeHistory> RecipeHistroys { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<GroupPrivilege> GroupPrivileges { get; set; }
    public DbSet<SecuritySettings> SecuritySettings { get; set; }
    public DbSet<AuditTrail> AuditTrails { get; set; }
    public DbSet<AlarmLog> AlarmLogs { get; set; }
    public DbSet<LoadCell> LoadCells { get; set; }
    public DbSet<LoadCellCalibration> LoadCellCalibrations { get; set; }
    public DbSet<ServoCalibration> ServoCalibrations { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoadCell>()
            .HasIndex(x => x.LoadCellCode)
            .IsUnique();
        base.OnModelCreating(modelBuilder);
    }
}
