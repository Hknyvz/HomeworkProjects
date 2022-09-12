using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityDbMapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName(nameof(User.Id));
            builder.Property(p => p.FirstName).HasColumnName(nameof(User.FirstName)).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).HasColumnName(nameof(User.LastName)).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnName(nameof(User.Email)).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Status).HasColumnName(nameof(User.Status));
            builder.Property(p => p.RefreshTokens).HasColumnName(nameof(User.RefreshTokens));
            builder.Property(p => p.AuthenticatorType).HasColumnName(nameof(User.AuthenticatorType));
            builder.Property(p => p.PasswordHash).HasColumnName(nameof(User.PasswordHash));
            builder.Property(p => p.PasswordSalt).HasColumnName(nameof(User.PasswordSalt));
            builder.HasMany(p => p.UserOperationClaims);
        }
    }
}
