using Microsoft.EntityFrameworkCore;

namespace PrograWebProyecto.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> tblUser { get; set; }
        public DbSet<Cargo> tblCargo { get; set; }
        public DbSet<Turno> tblTurno { get; set; }
        public DbSet<Genero> tblGenero { get; set; }
        public DbSet<Civil> tblCivil { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var conString = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conString);
        }
    }
}
