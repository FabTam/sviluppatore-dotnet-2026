/*
DECORATORS

 I decoratori sono un modo di modificare il comportamento di una classe o di un metodo senza modificare il codice originale.
 In c#, i decoratori sono implementati utilizzando gli attributi.

 STUDIA LE REGULAR EXPRESSIONS PER IMPLEMENTARE DIVERSI DECORATORI
*/

// per usarli

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// tramite i decoratori possiamo validare i dati di input di una classe, ad esempio in un modello di dati, o in un controller


// posso stamparlo nella console se mi serve vedere l'errore

LastId2 lastId = new LastId2();
lastId.Id = -1; // questo genera un eerrore

var context = new ValidationContext(lastId);

try
{
    Validator.ValidateObject(lastId, context, true);

}

catch(ValidationException ex)
{
    Console.WriteLine(ex.Message);
}

public class LastId
{
    public int Id {get; set;}
}

public class Contatto
{
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Cognome {get; set;}
    public string Email {get; set;}

    public string Telefono {get; set;}
    public List<string> Interessi {get; set;}

}

// Nella classe LastId2, possiamo utilizzare un decoratore [Range] per validare che l'ID sia un un numero intero positivo

public class LastId2
{
    [Range(0, int.MaxValue, ErrorMessage = "L'ID deve essere un numero intero positivo")]
    public int Id {get; set;}
}

/*
  Questo significa che la classe non accetterà valori negativi per L?ID e restituirà un messaggio di errore se si tenta di assegnare un valore non valido.
*/

// nella classe Contatto 2 possiamo utilizzare il decoratore [required] per validare che i campi Nome e Cognome siano obbligatori e [StringLength] per validare la lunghezza dei campi.
// Email adress verifica che il campo email contenga una chiocciola alla quale segue un punto ed un dominio.

public class Contatto2
{
    public int Id {get; set;}

    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [StringLength(50,ErrorMessage = "Il nome non può superare i 50 caratteri")]
    public string Nome {get; set;}

    [Required(ErrorMessage = "Il cognome è obbligatorio")]
    [StringLength(50,ErrorMessage = "Il cognome non può superare i 50 caratteri")]
    public string Cognome {get; set;}

    [EmailAddress(ErrorMessage = "L'email non è valida.")]
    public string Email {get; set;}

    public string Telefono {get; set;}
    
    [MinLength(1,ErrorMessage = " La lista deve contenere almeno un elemento")]
    public List<string> Interessi {get; set;}

}