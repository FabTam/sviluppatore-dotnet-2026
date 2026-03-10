using System.ComponentModel.DataAnnotations;
using Rubrica.Api.Models;

public class User
{
  [Required]
  [StringLength(50)]
  public string Username {get;set;} = string.Empty;
  [Required]
  public string PasswordHash {get;set;} = string.Empty;
  [Required]
  [StringLength(20)]
  public string Ruolo {get;set;} = "User";

  // un utente può avere molti contatti

 public List<Contatto> Contatti{get;set;} = new();
}