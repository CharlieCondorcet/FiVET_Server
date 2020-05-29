using System.Reflection;
using Fivet.ZeroIce.model;
using Microsoft.EntityFrameworkCore;

namespace Fivet.Dao
{
    /// <summary>
    /// The Connection to the FivetDatabase.
    /// </summary>
    public class FivetContext : DbContext
    {
        /// <summary>
        /// The Connection to the database.
        /// </summary>
        /// <value> </value>
        public DbSet<Persona> Personas { get; set; }

        /// <summary>
        /// Configuration.
        /// </summary>
        /// <param name="optionsBuilder"> </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using SQLite
            optionsBuilder.UseSqlite("Data Source=fivet.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder); 
        }
        
        /// <summary>
        /// Create the ER from Entity.
        /// </summary>
        /// <param name="modelBuilder">to use</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(p =>
            {
                // Primary Key
                p.HasKey(p => p.uid); 
                // Index in Email
                p.Property(p => p.email).IsRequired();
                p.HasIndex(p => p.email).IsUnique();
            });

            // Insert the database
            modelBuilder.Entity<Persona>().HasData(
                new Persona()
                {
                    uid = 1,
                    nombre= "Charlie",
                    direccion = "Lenka Franulik #1922",
                    telefonoFijo = 02554433, 
                    telefonoMovil = 56944556677,
                    email = "charlie@gmail.com"
                }
            );
                
        }

    }

}