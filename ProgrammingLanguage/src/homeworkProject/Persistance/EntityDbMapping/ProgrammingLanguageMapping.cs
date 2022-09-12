using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityDbMapping
{
    internal class ProgrammingLanguageMapping : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.ToTable(nameof(ProgrammingLanguage)).HasKey(k=>k.Id);
            builder.Property(p => p.Id).HasColumnName(nameof(ProgrammingLanguage.Id));
            builder.Property(p => p.Name).HasColumnName(nameof(ProgrammingLanguage.Name)).IsRequired().HasMaxLength(20);
            builder.HasMany(p => p.Technologies);
        }
    }
}
