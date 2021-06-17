using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class OcenaConfiguration : IEntityTypeConfiguration<Ocena>
    {
        public void Configure(EntityTypeBuilder<Ocena> builder)
        {
            builder.Property(x => x.Vrednost).IsRequired();
            builder.HasIndex(x => x.Vrednost);

            
        }
    }
}
