/*
Class Program Main

Nelle applicazioni Dotnet il file Program.cs è il punto di ingresso dell'applicazione, dove viene eseguito il codice principale. In questo file, puoi creare istanze di classi, chiamare metodi e gestire
la logica principale del tuo programma.

Quando in una cartella sono presenti più file .cs, è necessario specificare quale classe contiene il metodo Main che deve essere eseguito all'avvio dell'applicazione. Se non viene specificato,
il compilatore cercherà una classe con un metodo Main e lo utilizzerà come punto di ingresso.

Se vogliamo suddividere il nostro programma in più classi, possiamo creare più files .cs per organizzare meglio il codice. In questo modo, possiamo mantenere il codice più pulito e modulare,
facilitando la manutenzione e la comprensione del programma.

Il secondo vantaggio pratico è che posso utilizzare il main in qualsiasi punto del programma, non solo sopra le classi ma anche sotto. Tutttavia è buona pratica organizzare le classi in file
separati per migliorare la leggibilità e la manutenzione del codice.

*/

// Esempio BLOCCO MAIN


class Program
{
    // la firma del metodo Main è sempre la stessa, con un array di stringhe come parametro che sono poi i comandi che inseriamo nel terminale.
    static void Main(string[] args)
    {
        // codice del main
    }
}