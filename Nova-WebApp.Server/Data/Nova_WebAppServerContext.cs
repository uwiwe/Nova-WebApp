using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nova_WebApp.Server.Models;

namespace Nova_WebApp.Server.Data
{
    public class Nova_WebAppServerContext : DbContext
    {
        public Nova_WebAppServerContext (DbContextOptions<Nova_WebAppServerContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configuracion para establecer automaticamente fecha de creacion
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");  // "GETDATE()" para hora local

            // unique index for email and phone
            modelBuilder.Entity<User>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();  // Asegura que EmailAddress sea único en la base de datos

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();  // Asegura que PhoneNumber sea único en la base de datos
        }

        // Metodo para verificar si el correo electronico ya esta registrado
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await User.AnyAsync(u => u.EmailAddress == email);
        }

        public async Task<bool> PhoneNumberExistsAsync(string phoneNumber)
        {
            return await User.AnyAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}
