using CompressionForce.Data.Configurations;
using CompressionForce.Data.Entities;
using CompressionForce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompressionForce.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        // ❌ REMOVE parameterless constructor if possible
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlarmLog> AlarmLogs { get; set; }
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<BatchHistory> BatchHistories { get; set; }
        public virtual DbSet<CurrentBatch> CurrentBatches { get; set; }
        public virtual DbSet<Privilage> Privilages { get; set; }
        public virtual DbSet<PrivilageHistory> PrivilageHistories { get; set; }
        //public virtual DbSet<Recipe> Recipes { get; set; }
        //public virtual DbSet<RecipeHistory> RecipeHistroys { get; set; }
        /*public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<RecipeHistoryEntity> RecipeHistories { get; set; }
        public DbSet<LookupValueEntity> LookupValues { get; set; }*/
            public DbSet<RecipeEntity> Recipes => Set<RecipeEntity>();
    public DbSet<RecipeHistoryEntity> RecipeHistories => Set<RecipeHistoryEntity>();
    public DbSet<LookupValueEntity> LookupValues => Set<LookupValueEntity>();
        public virtual DbSet<ResultEjectLoadS1B> ResultEjectLoadS1Bs { get; set; }
        public virtual DbSet<ResultEjectLoadS2B> ResultEjectLoadS2Bs { get; set; }
        public virtual DbSet<ResultMainLoadS1B> ResultMainLoadS1Bs { get; set; }
        public virtual DbSet<ResultMainLoadS2B> ResultMainLoadS2Bs { get; set; }
        public virtual DbSet<ResultMainSrelS1B> ResultMainSrelS1Bs { get; set; }
        public virtual DbSet<ResultMainSrelS2B> ResultMainSrelS2Bs { get; set; }
        public virtual DbSet<ResultPreLoadS1B> ResultPreLoadS1Bs { get; set; }
        public virtual DbSet<ResultPreLoadS2B> ResultPreLoadS2Bs { get; set; }
        public virtual DbSet<ServoCalibration> ServoCalibrations { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserLoginHistroy> UserLoginHistroys { get; set; }
        public virtual DbSet<UserManagement> UserManagements { get; set; }
        public virtual DbSet<UserManagementHistroy> UserManagementHistroys { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<RecipeEntity>().Property(x => x.Parameters).HasColumnType("jsonb");

            modelBuilder.Entity<RecipeHistoryEntity>()
                .Property(x => x.OldParameters)
                .HasColumnType("jsonb");

            modelBuilder.Entity<RecipeHistoryEntity>()
                .Property(x => x.NewParameters)
                .HasColumnType("jsonb");*/
            modelBuilder.ApplyConfiguration(new RecipeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeHistoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LookupValueEntityConfiguration());

            // ALL YOUR EXISTING MODEL CONFIGURATION CAN STAY AS IS
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
