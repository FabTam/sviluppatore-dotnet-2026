// METODI STRING

string nome = " Nome1 ";

int lunghezza = nome.Length; // .length restituisce il numero dei caratteri di una stringa.

Console.WriteLine(lunghezza);

Console.WriteLine(string.IsNullOrWhiteSpace(nome)); // accedo al metodo della stringa che verifica se è nulla o vuota o contiene spazi. Ritorna un booleano

Console.WriteLine(string.IsNullOrEmpty(nome)); // accedo al metodo della che verifica se è nulla o vuota. Ritorna un booleano

Console.WriteLine(nome.ToLower()); // metodo della variabile che restituisce il nome in minuscolo.

Console.WriteLine(nome.ToUpper()); // metodo della variabile che restituisce il nome in maiuscolo.

Console.WriteLine(nome.Trim()); // metodo della variabili che rimuove gli spazi iniziali e finali.


// SPLIT E JOIN 

string nomi = "Nome1, Nome2, Nome3, Nome4, Nome5";

string [] nomiArray = nomi.Split(","); // divide una stringa in base ad un separatore.

foreach(string n in nomiArray) // uso un alias per ogni elemento dell'array, perchè rimane in locale.
{
    Console.WriteLine(n);
}

string nomiUniti = string.Join(", ", nomiArray); // unisce gli elementi di un array in una stringa usando un separatore.

Console.WriteLine(nomiUniti);

//

string sostituzione = nome.Replace("Nome", "Cognome");

Console.WriteLine(sostituzione); // sostituisce la stringa nel primo argomento con quella del secondo argomento.

Console.WriteLine(nome.Substring(0,2)); // restituisce una sottostringa a partire da un indice ed una lunghezza(partendo dalla lettera in posizione 0 e prende 2 caratteri)

Console.WriteLine(nome.Contains("nom")); // verifica se una stringa contiene una sottostringa e restituisce un booleano.

Console.WriteLine(nome.StartsWith("nom")); // verifica se inizia con una sottostringa e restituisce un booleano.

Console.WriteLine(nome.EndsWith("me1")); // verifica se finisce con una sottostringa e restituisce un booleano.


/* ESERCITAZIONE
Programma che usa un array string con 5 nomi ed una variabile string per il contenuto da cercare.
Chiede all'utente di inserire una parte del nome da cercare
Verifica se il nome inserito è presente nell'array e stampa un messaggio di errore se non presente.
Se il nome è presente stampa il messaggio del nome completo.

*/


string[] nomiDaCercare = { "fabio", "andrea", "lorenzo", "francesco", "enrico" };

Console.Write("Inserisci una parte del nome da cercare: ");
string input = Console.ReadLine();

bool nomeTrovato = false;

foreach (string n in nomiDaCercare)
{
    
    if (n.Contains(input.ToLower()))
    {
        Console.WriteLine($"Nome trovato: {n}");
        nomeTrovato = true;
        break;// Esce dal ciclo dopo aver trovato il primo nome che contiene la stringa cercata
    }
}

if (!nomeTrovato)
{
    Console.WriteLine("Nome non trovato");
}





