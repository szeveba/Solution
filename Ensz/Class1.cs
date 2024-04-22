using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ensz
{
    //[Table("orszag")]
    public class Ország
    {
        [Key, StringLength(32, MinimumLength = 1)]
        public string? ID { get; set; }
        [Required, StringLength(100)]
        public string? Név { get; set; }
        [Required]
        public int? Terület { get; set; }
        [Required]
        public int? Népesség { get; set; }
        [Required]
        public Város? Főváros { get; set; }
    }

    public class Város
    {
        [Key, MinLength(1), MaxLength(32)]
        public string? ID { get; set; }
        [Required, StringLength(100)]
        public string? Név { get; set; }
        [Required]
        public int? Népesség { get; set; }
    }

    public class Context : DbContext
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Szegedi Barnabás\\source\\repos\\Solution\\Ensz\\EnszDatabase.mdf\";Integrated Security=True";
        public DbSet<Ország> Országok { get; set; }
        public DbSet<Város> Városok { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
