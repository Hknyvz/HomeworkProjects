using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityDbMappings
{
    public class OperationClaimMapping : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable(nameof(OperationClaim)).HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnName(nameof(OperationClaim.Name)).IsRequired().HasMaxLength(50);
            builder.HasMany(p => p.UserOperationClaims);
        }
    }
}
