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

// Le classi statiche vanno in services, le altre vanno in cartelle come Controllers e Models, al cui interno avremo i file .cs delle varie classi.

/*
 NAMESPACES

 I namespaces sono utilizzati per oranizzare le classi e i metodi in gruppi logici, evitando conflitti di nomi tra classi con lo stesso nome.
 Un namespace è definito utilizzando la parola chiave namespace, seguita dal nome del namespace

*/

namespace MyApplication
{
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}

/*
  In questo caso il file Program comunica agli altri file che la classe Program appartiene al namespace MyApplication. In questo modo, se in un altro file abbiamo una classe con lo stesso nome,
  ad esempio Program possiamo distinguirli con il namespace.

  Quando vogliamo usare una determinata classe definita da un namespace dobbiamo usare usingMyApplication.
*/