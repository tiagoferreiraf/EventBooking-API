using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            // Chave primária
            builder.HasKey(u => u.Id);

            // Mapeamento das propriedades
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();

            // Configuração da relação com Reservations
            builder.HasMany(u => u.Reservations) // Um User pode ter várias Reservations
                .WithOne(r => r.User) // Uma Reservation pertence a um User
                .HasForeignKey(r => r.UserId) // Chave estrangeira em Reservation referenciando UsuarioId
                .IsRequired(); // Define a relação como obrigatória
        }
    }
}
