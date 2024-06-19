﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
{
    public void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        builder.ToTable("Agendamentos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Observacao)
            .IsRequired(false)
            .HasColumnType("Varchar(250)");

        builder.Property(x => x.PacienteId)
            .IsRequired();
            
        builder.Property(x => x.MedicoId)
            .IsRequired();
    }
}

