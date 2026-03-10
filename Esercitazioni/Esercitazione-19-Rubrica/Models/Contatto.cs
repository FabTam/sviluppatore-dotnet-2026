using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Models;
public class Contatto
{
public int Id {get;set;}// chiave primaria
  [Required]
  [StringLength(100)]
  public string Nomecompleto {get;set;} = string.Empty;
  [Required]
  [StringLength(30)]
  public string Telefono {get;set;} = string.Empty;
  public bool IsActive {get;set;}
  public List<string> Competenze {get;set;} = new();
  public DateTime CreatedAt {get;set;} = DateTime.UtcNow;

  // foreign key: ogni contatto appartiene ad un utente
 public int UserId{get;set;}

 // proprietà di navigazione: EF Core usa questa proprietà
 // per collegare il contatto al suo utente

 public User User{get;set;} = null!;

}