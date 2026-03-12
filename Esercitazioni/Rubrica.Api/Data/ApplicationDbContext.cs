using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Models;

namespace Rubrica.Api.Data;

public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
{
    // costruttore che accetta le opzioni di configurazione di DbContext

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {


    }
    // DbSet per la tabella Interessi
    public DbSet<Interest> Interests { get; set; }

}