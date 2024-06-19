using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void Seed()
        {
            var roleIdAtendente = Guid.NewGuid().ToString();
            var roleIdMedico = Guid.NewGuid().ToString();
            var atendenteId = Guid.NewGuid().ToString();

            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleIdAtendente,
                    Name = "Atendente",
                    NormalizedName = "ATENDENTE"
                },
                new IdentityRole
                {
                    Id = roleIdMedico,
                    Name = "Medico",
                    NormalizedName = "MEDICO"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Atendende>().HasData(
                new Atendende
                {
                    Id = atendenteId,
                    Nome = "Pro Consulta",
                    Email = "proconsulta@gmail.com",
                    EmailConfirmed = true,
                    UserName = "PROCONSULTA@GMAIL.COM",
                    NormalizedEmail = "PROCONSULTA@GMAIL.COM",
                    NormalizedUserName = "PROCONSULTA@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "KMpb!8810@")
                }
            );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleIdAtendente,
                    UserId = atendenteId,
                }
            );

            _modelBuilder.Entity<Especialidade>().HasData(
                new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Especialidade médica que trata doenças do sistema cardiovascular." },
                new Especialidade { Id = 2, Nome = "Gastroenterologia", Descricao = "Especialidade médica que trata doenças do estômago e intestino." },
                new Especialidade { Id = 3, Nome = "Urologia", Descricao = "Especialidade médica que trata doenças do sistema urinário e masculino." },
                new Especialidade { Id = 4, Nome = "Neurologia", Descricao = "Especialidade médica que trata doenças do sistema nervoso." },
                new Especialidade { Id = 5, Nome = "Pediatria", Descricao = "Especialidade médica que trata de crianças e adolescentes." },
                new Especialidade { Id = 6, Nome = "Dermatologia", Descricao = "Especialidade médica que trata da pele e suas doenças." },
                new Especialidade { Id = 7, Nome = "Psiquiatria", Descricao = "Especialidade médica que trata doenças e distúrbios psicológicos." },
                new Especialidade { Id = 8, Nome = "Oftalmologia", Descricao = "Especialidade médica que trata dos olhos e sua visão." },
                new Especialidade { Id = 9, Nome = "Oncologia", Descricao = "Especialidade médica que trata o câncer." },
                new Especialidade { Id = 10, Nome = "Ginecologia", Descricao = "Especialidade médica que trata do sistema reprodutor feminino" }
            );
        }
    }
}
