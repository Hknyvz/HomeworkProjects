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
    public class UserOperationClaimMapping : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable(nameof(UserOperationClaim)).HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName(nameof(UserOperationClaim.Id));
            builder.Property(p => p.OperationClaimId).IsRequired().HasColumnName(nameof(UserOperationClaim.OperationClaimId));
            builder.Property(p => p.UserId).IsRequired().HasColumnName(nameof(UserOperationClaim.UserId));
            builder.HasOne(p => p.User);
            builder.HasOne(p => p.OperationClaim);
        }
    }
}
