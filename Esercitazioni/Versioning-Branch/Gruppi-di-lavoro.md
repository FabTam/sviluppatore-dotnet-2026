# Organizzazione Team

## Team 1
- Andrea B.
- Lorenzo
- Fabio
- Andrea P.

## Team 2
- Marco
- Alessandro
- Simeone
- Francescos


## App Cinema
- Cinema con x sale, x film, x posti.
- Acquirenti comprano i biglietti.
- Promozioni/abbonamenti, bundle biglietti, carnet.
- Ruoli: admin, acquirente, gestore della sala(editor).



## App Casa coinquilini
- Case a disposizione con numero di stanze, prezzo per stanza, numero di inquilini.
- Utenti che si iscrivono, proprietario di casa e admin del "sito".
- possibilità di filtrare la ricerca di una stanza in base al prezzo.(lato front)
- Schede degli utenti che possono essere visualizate per capire se c'è compatibilità.
- Un utente mostra interesse per una stanza, se l'host conferma allora la stanza è di quell'utente.


# Organizzazione del lavoro:

## Modelli:
 ## Ruoli

 ```C#
[Table("Users")] // decorator che permette di definire a quale tabella appartiene la tabella.
public class ApplicationUser : IdentityUser
{
    // IdentityUser ha già: Id, UserName, Email, PasswordHas, PhoneNumber ecc

    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;

    public int Eta {get;set;}


    // un utente può avere molti biglietti

    public List<Biglietto> Biglietti { get; set; } = new List<Biglietto>();
}
```

## Sala.cs

```C#
    public class Sala
    {
        [Table("Sala")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome {get;set;} = string.Empty;

        public int NumeroPosti {get;set;}

        public DateTime Orario {get;set;}

        [Required]
        public string BigliettoId { get; set; } = string.Empty;

        // collegamento al biglietto.

        [ForeignKey("BigliettoId")]
        public List<Biglietto> Biglietti { get; set; }

    }

```

## Film.cs

```C#
    public class Film
    {
        [Table("Film")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titolo {get;set;} = string.Empty;

        public string Genere {get;set;} = string.Empty;

        public string Descrizione {get; set;} = string.Empty;

        public int Durata {get;set;}

        [Required]
        public string BigliettoId { get; set; } = string.Empty;

        // collegamento al biglietto.

        [ForeignKey("BigliettoId")]
        public List<Biglietto> Biglietti { get; set; }
    }
```
 ## Biglietto.cs

```C#

 public class Biglietto
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        
        public double Prezzo {get;set;}


        [Required]
        public string FilmId { get; set; } = string.Empty;

        [Required]
        public string SalaId {get;set;} = string.Empty;

        // collegamento a film, sala e utente.

        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        [ForeignKey("SalaId")]
        public Sala Sala { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
    ```
