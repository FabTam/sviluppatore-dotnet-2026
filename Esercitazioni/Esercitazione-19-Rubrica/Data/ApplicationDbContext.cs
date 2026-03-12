using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Esercitazione_19_Rubrica.Models;

public class ApplicationDbContext : DbContext
{
    // costruttore che accetta le opzioni di configurazione di DbContext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // qui non serve aggiungere niente, il costruttore base si occupa di configurare il DbContext con le opzioni fornite in Program.cs
    }

    // DbSet per la tabella Contatti
    public DbSet<Interest> Interests {get;set;}
   

}