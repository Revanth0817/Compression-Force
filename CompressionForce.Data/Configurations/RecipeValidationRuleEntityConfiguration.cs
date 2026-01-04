
using CompressionForce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompressionForce.Data.Configurations
{
    public class RecipeValidationRuleEntityConfiguration : IEntityTypeConfiguration<RecipeValidationRuleEntity>
    {
        public void Configure(EntityTypeBuilder<RecipeValidationRuleEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}


/*When you move to DB-backed validation, 
 add modelBuilder.ApplyConfiguration(new RecipeValidationRuleEntityConfiguration()); 
in ApplicationDbContext.OnModelCreating.
*/