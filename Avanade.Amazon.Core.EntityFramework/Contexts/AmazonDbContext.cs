using Avanade.Amazon.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avanade.Amazon.Core.DataAccessLayers.Contexts
{
    /// <summary>
    /// Db contex for Azure SQL
    /// </summary>
    public class AmazonDbContext: DbContext
    {
        /// <summary>
        /// Books
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Configures access to remote database
        /// </summary>
        /// <param name="optionsBuilder">Options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Stringa di connessione per Azure SQL
            const string connectionString = "Server=tcp:avanade-sql-srv.database.windows.net,1433;" +
                "Initial Catalog=avanade-amazon-db;Persist Security Info=False;User ID=maurobussini;" +
                "Password=Academy2022!;MultipleActiveResultSets=False;Encrypt=True;" +
                "TrustServerCertificate=False;Connection Timeout=30;";

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
            modelBuilder.Entity<Book>().ToTable("Books");

            //Creazione del modello base
            base.OnModelCreating(modelBuilder);
        }
    }
}
