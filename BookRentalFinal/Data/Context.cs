using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookRentalFinal.Data
{
    class Context : DbContext
    {
        const string devConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Szegedi Barnabás\\source\\repos\\Solution\\BookRentalFinal\\Data\\DevelopmentDatabase.mdf\";Integrated Security=True";
        const string productionConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder()
                    .AddUserSecrets<Context>()
                    .Build();

            var connectionString = configuration["AzureDBConnection"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
