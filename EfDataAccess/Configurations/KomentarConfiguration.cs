using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KomentarConfiguration : IEntityTypeConfiguration<Komentar>
    {
        public void Configure(EntityTypeBuilder<Komentar> builder)
        {
            builder.Property(x => x.Vrednost).IsRequired();
            builder.HasIndex(x => x.Vrednost);

            
        }
    }
}
