using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome)
            .IsRequired(true)
            .HasColumnType("Varchar(50)");
        
        builder.Property(x => x.Documento)
            .IsRequired(true)
            .HasColumnType("NVarchar(11)");

        builder.HasIndex(x => x.Documento)
            .IsUnique();

        builder.Property(x => x.Email)
            .IsRequired(true)
            .HasColumnType("Varchar(50)");

        builder.Property(x => x.Celular)
            .IsRequired(true)
            .HasColumnType("NVarchar(11)");

        builder.HasMany(a => a.Agendamentos)
            .WithOne(p => p.Paciente)
            .HasForeignKey(a => a.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

