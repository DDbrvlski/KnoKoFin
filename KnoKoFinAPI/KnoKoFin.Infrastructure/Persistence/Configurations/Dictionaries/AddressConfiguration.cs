﻿using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Persistence.Configurations.Dictionaries
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Tabela i schemat
            builder.ToTable("addresses", schema: "dictionaries");

            // Kolumny i ich właściwości
            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("STREET")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(a => a.PostCode)
                .IsRequired()
                .HasColumnName("POSTCODE")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnName("CITY")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnName("COUNTRY")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
