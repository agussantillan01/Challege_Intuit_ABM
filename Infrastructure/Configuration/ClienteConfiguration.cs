using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Apellido).HasColumnName("Apellido").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.FechaNacimiento).HasColumnName("FechaNacimiento").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Cuit).HasColumnName("CUIT").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Domicilio).HasColumnName("Domicilio").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Telefono).HasColumnName("TelefonoCelular").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(500).IsRequired();
        }
    }
}
