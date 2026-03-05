using System.ComponentModel.DataAnnotations;
public class Contatto
{
   public int Id { get; set; }
   [Required(ErrorMessage = "Il nome è obbligatorio.")]
   public string Nome { get; set; }
   [Required(ErrorMessage = "L'età è obbligatoria.")]

   public string Eta { get; set; }
   public bool Presente { get; set; }
  [MinLength(1, ErrorMessage = "La lista di interessi deve contenere almeno un interesse.")]
   public List<string> Interessi { get; set; }
}
