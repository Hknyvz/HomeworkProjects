using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityDbMappings
{
    internal class TechnologyMapping : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable(nameof(Technology)).HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName(nameof(Technology.Id));
            builder.Property(p => p.Name).HasColumnName(nameof(Technology.Name)).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasColumnName(nameof(Technology.Description)).HasMaxLength(500).IsRequired();
            builder.Property(p => p.IsOpenSource).HasColumnName(nameof(Technology.IsOpenSource));
            builder.HasOne(p => p.ProgrammingLanguage);
        }
    }
}
