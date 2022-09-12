using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityDbMappings
{
    public class RefreshTokenMapping : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable(nameof(RefreshToken)).HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName(nameof(RefreshToken.Id));
            builder.Property(p => p.Expires).HasColumnName(nameof(RefreshToken.Expires));
            builder.Property(p => p.Token).HasColumnName(nameof(RefreshToken.Token));
            builder.Property(p => p.ReplacedByToken).HasColumnName(nameof(RefreshToken.ReplacedByToken));
            builder.Property(p => p.Revoked).HasColumnName(nameof(RefreshToken.Revoked));
            builder.Property(p => p.RevokedByIp).HasColumnName(nameof(RefreshToken.RevokedByIp));
            builder.Property(p => p.Created).HasColumnName(nameof(RefreshToken.Created));
            builder.Property(p => p.CreatedByIp).HasColumnName(nameof(RefreshToken.CreatedByIp));
            builder.Property(p => p.UserId).HasColumnName(nameof(RefreshToken.UserId));
            builder.HasOne(p => p.User);
        }
    }
}
