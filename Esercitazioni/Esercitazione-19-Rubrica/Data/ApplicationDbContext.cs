using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    // costruttore che accetta le opzioni di configurazione di DbContext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // qui non serve aggiungere niente, il costruttore base si occupa di configurare il DbContext con le opzioni fornite in Program.cs
    }

    // DbSet per la tabella Contatti
    public DbSet<Contatto> Contatti {get;set;}
    public DbSet<User> Users {get;set;}

}