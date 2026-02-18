/*
FUNZIONI
- una funzione è un blocco di codice che esegue un compito specifico.
- Può essere riutilizzata più volte all'interno di un programma.
- il vantaggio di usare le funzioni è che il codice diventa più leggibile e modulare.

Ci sono 2 tipi di funzioni:

- Funzioni che elaborano i dati però non restituiscono un valore(void).
- Funzioni che elaborano i dati e restituiscono un valore(return) che può essere raccolto/usato dal resto dell'applicazione
   -> sono definite con un tipo di ritorno.
-

Una funzione è definita da:

- Un tipo di ritorno.
- Nome della funzione.
- Una lista di parametri(opzionale).
- Un corpo della funzione.
- Un'istruzione di ritorno(opzionale).

IMPORTANTE:

- Una funzione in csharp deve avere il nome scritto in PascalCase.
- Una funzione deve svolgere un compito specifico e non deve essere troppo lunga.
- Una funzione può avere un solo return, ma può essere chiamata più volte.
- Una variabile definita all'interno di una funzione è visibile solo all'interno di quella funzione(scope locale).

*/

void NomeFunzione()
{
    // corpo della funzione. Void non restituisce risultati.
}

void Stampa()
{
    Console.WriteLine("Funzione void");
}


void NomeFunzione2(string parametro1, int parametro2) // void con parametri
{
    // corpo della funzione
}

/*
PARAMETRI

Sono delle variabili che vengono passate alla funzione quando questa funzione viene chiamata.
La chiamata della funzione avviene scrivendo: NomeFunzione(parametri)
*/

NomeFunzione2("parametro1", 1); // Passiamo i due parametri, uno di tipo string e uno di tipo int.

/*
Ci sono parametri e argomenti: ciò che passiamo alla creazione della funzione si chiama parametro, ciò che passiamo alla chiamata sono gli argomenti.
*/

int NomeFunzione3()
{
    return 0; // valore di ritorno viene restituito dal corpo del codice
}

int Somma(int a, int b)
{
    return a + b;
}

Somma(1, 2);


/*
Le funzioni possono elaborare sia dati semplice che complessi. Ma possono anche chiamare altre funzioni al loro interno per eseguire compiti specifici.
Una funzione NON può richiamare sé stessa, ma può farlo attraverso altre funzioni. Le funzioni ricorsive esistono ma devono essere trattate in altro modo.
*/

int SommaArray(int[] numeri)
{
    int somma = 0;
    foreach (int n in numeri)
    {
        somma += n;

    }
    return somma;
}

int[] numeri = {1,2,3,4,5};

int risultato = SommaArray(numeri); // definisco una variabile a cui associo il ritorno della funzione passando come argomento l'array definito.

Console.WriteLine($"La somma dei numeri nell'array è {risultato}");

// FUNZIONE CHE RICHIAMA UN'ALTRA FUNZIONE

void StampaMessaggio(string messaggio)
{
    Console.WriteLine(messaggio);
}

void StampaMessaggioConPrefisso(string messaggio)
{
    string prefisso = "Prefisso";
    StampaMessaggio($"{prefisso}{messaggio}");
}

StampaMessaggioConPrefisso("Questo è un messaggio con prefisso");

int Doppio(int numero)
{
    return numero * 2;
}

int Quadruplo(int numero)
{
    int doppio = Doppio(numero);
    return doppio * 2;
}

void StampaRaddoppiaDoppio(int numero)
{
    int quadruplo = Quadruplo(numero);
    Console.WriteLine($"Il raddoppio del doppio di {numero } è {quadruplo}");
}

StampaRaddoppiaDoppio(5);


/*
ESERCITAZIONE:
- Unisci due liste
- restituisce una lista con tutti gli elementi
- ed una funzione che stampa la lista unita
*/

List<string> UnisciListe(List<string> lista1, List<string> lista2)
{
   List<string> listaUnita = new List<string>();
   // listaUnita.AddRange(lista1);
   // listaUnita.AddRange(lista2);
   foreach(string l in lista1)
    {
        listaUnita.Add(l);
    }
 
   foreach(string l in lista2)
    {
        listaUnita.Add(l);
    }

    return listaUnita;
}

void StampaLista(List<string> lista)
{
    foreach(string l in lista)
    {
        Console.WriteLine(l);
    }
}

List<string> primaLista = new List<string>()
{
    "Fabio",
    "Enrico",
    "Lorenzo"
};

List<string> secondaLista = new List<string>()
{
    "Marco",
    "Laura",
    "Elisa"
};

List<string> listaUnita = UnisciListe(primaLista, secondaLista); // devo salvare il ritorno di funzione in una lista

StampaLista(listaUnita);

