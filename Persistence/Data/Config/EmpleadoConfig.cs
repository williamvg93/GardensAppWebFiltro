using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.HasKey(e => e.CodigoEmpleado).HasName("PRIMARY");

        builder.ToTable("empleado");

        builder.HasIndex(e => e.CodigoJefe, "FK_empleado_codigo_jefe_empleado_codigo_empleado");

        builder.HasIndex(e => e.CodigoOficina, "FK_empleado_codigo_oficina_oficina_codigo_oficina");

        builder.Property(e => e.CodigoEmpleado)
            .ValueGeneratedNever()
            .HasColumnName("codigo_empleado");
        builder.Property(e => e.Apellido1)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("apellido1");
        builder.Property(e => e.Apellido2)
            .HasMaxLength(50)
            .HasColumnName("apellido2");
        builder.Property(e => e.CodigoJefe).HasColumnName("codigo_jefe");
        builder.Property(e => e.CodigoOficina)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("codigo_oficina");
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("email");
        builder.Property(e => e.Extension)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("extension");
        builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("nombre");
        builder.Property(e => e.Puesto)
            .HasMaxLength(50)
            .HasColumnName("puesto");

        builder.HasOne(d => d.CodigoJefeNavigation).WithMany(p => p.InverseCodigoJefeNavigation)
            .HasForeignKey(d => d.CodigoJefe)
            .HasConstraintName("FK_empleado_codigo_jefe_empleado_codigo_empleado");

        builder.HasOne(d => d.CodigoOficinaNavigation).WithMany(p => p.Empleados)
            .HasForeignKey(d => d.CodigoOficina)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_empleado_codigo_oficina_oficina_codigo_oficina");

    }


}