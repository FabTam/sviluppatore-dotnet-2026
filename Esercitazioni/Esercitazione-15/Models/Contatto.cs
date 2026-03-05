using System.ComponentModel.DataAnnotations;
public class Contatto
{
   public int Id { get; set; }
   [Required(ErrorMessage = "Il nome è obbligatorio.")]
   [StringLength(50, MinimumLength = 2, ErrorMessage = "Il nome deve essere compreso tra 2 e 50 caratteri.")]
   public string Nome { get; set; }

   [Required(ErrorMessage = "L'età è obbligatoria.")]
   public string Eta { get; set; }

   [Required(ErrorMessage = "La presenza è obbligatoria.")]
   public bool Presente { get; set; }

  [MinLength(2, ErrorMessage = "La lista di interessi deve contenere almeno due interessi.")]
   public List<string> Interessi { get; set; }
}
