using AgenziaConsulenzaAMM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF
{
    public class ContextDB:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Progetto> Projects { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        /// <summary>
        /// Configures access to remote database
        /// </summary>
        /// <param name="optionsBuilder">Options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Stringa di connessione per Azure SQL
            const string connectionString = "Server=tcp:avanadeamm-sql-srv.database.windows.net,1433;Initial Catalog=GestioneProgetto;Persist Security Info=False;User ID=mariadestefano;Password=AcademyAMM2022!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //Passo a EF la connessione al database Azure
            optionsBuilder.UseSqlServer(connectionString);

            //Configurazione base
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Maps entities and tables on database
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mappatura delle entità (con le relative tabelle)
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Progetto>().ToTable("Projects");
            modelBuilder.Entity<Timesheet>().ToTable("Timesheets");

            //Creazione del modello base
            base.OnModelCreating(modelBuilder);
        }
    }
}
