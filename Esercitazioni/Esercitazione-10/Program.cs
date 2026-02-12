/* METODI LIST
 A differenza degli array le list hanno molti più metodi disponibii per manipolarle. 
 Questo è dovuto al fatto che le liste hanno un numero variabile di elementi.
 Come ogni struttura devono contenere elementi dello stesso tipo.
*/

/*
ADD
aggiunge un elemento alla lista. Se la lista è già piena, viene automaticamente ridimensionata per accogliere il nuovo elemento.
*/

using System.Data;
using System.Xml;

List<int> numeri = new List<int>();
numeri.Add(1);
numeri.Add(2);
Console.WriteLine(string.Join(",", numeri));

/*
COUNT
Il metodo count restituisce il numero di elementi presenti nella lista.
*/

Console.WriteLine(numeri.Count);// output : 2

/*
ADD RANGE
Il metoto AddRange permettte di aggiungere più elementi alla lista in un colpo solo. Oppure permette di aggiungere ad una lista un'altra lista
*/
numeri.AddRange([3,4,5,6]);
numeri.AddRange(7,8,9);
Console.WriteLine(string.Join(",", numeri));

List<int> numeri2 = new List<int>(){10,11,12};
numeri.AddRange(numeri2);
Console.WriteLine(string.Join(",", numeri));

/*
CONTAINS
Verifica se l'elemento è presente nella lista. Restituisce un true o false(booleano)
*/

Console.WriteLine(numeri.Contains(3)); // output: true

/*
INDEX OF
Trova l'indice dell'elemento in una lista(se non trova il valore restituisce -1)
*/

Console.WriteLine(numeri.IndexOf(5));// output: 4
Console.WriteLine(numeri.IndexOf(30));// output:-1

/*
SORT
Il metodo sort permette di ordinare gli elementi della lista in ordine crescente.
*/

numeri.Sort();
Console.WriteLine(string.Join(",",numeri));

/*
REVERSE
Il metodo revrse permette di invertire l'ordine degli elementi
*/

numeri.Reverse();
Console.WriteLine(string.Join(",",numeri));

/*
TOARRAY
Permette di onvertire una lista in un array
*/

int[] numeriArray = numeri.ToArray();
Console.WriteLine(string.Join(",", numeriArray));

/* INSERT
Il Comando Insert permette di inserire un elemento in una posizione specifica della lista.
*/

numeri.Insert(0,1); // inserisce il numero 1 all'inizio della lista
Console.WriteLine(string.Join(",", numeri));


/*
REMOVE
Il metodo remove permette di rimuovere un elemento dalla lista(restituisce un booleano)
*/

Console.WriteLine(numeri.Remove(5));
Console.WriteLine(numeri.Remove(39));
Console.WriteLine(string.Join(",",numeri)); // lista senza il 5

/*
REMOVEAT
Il metodo remove permette di rimuovere un elemento dalla lista ad un dato elemento
*/

numeri.RemoveAt(0);
Console.WriteLine(string.Join(",",numeri));

/*
CLEAR
Il metodo remove permette di rimuovere tutti gli elementi della lista.
*/

numeri.Clear();
Console.WriteLine(string.Join(",",numeri));


/*
TRIMEXCESS
*/
Console.WriteLine(numeri.Count);
numeri.RemoveRange(0,0);
numeri.TrimExcess();
Console.WriteLine(numeri.Count);




/*

ESERCITAZIONE

Programma che: 
- chiede all'utente di inserire nomi ad una lista finchè non viene inserito 0
- viene estratto un nome casuale dalla lista e stampato a video
- viene chiesto all'utente se vuole estrarre un altro nome casuale, se "y" viene estratto un altro nome casuale e stampato altrimenti il programma termina
- il nome estratto deve essere rimosso una volta estratto e stampato.
*/


List<string> nomi = new List<string>();
Random random = new Random();

while(true)
{
  Console.Write("Inserisci di seguito il nome da inserire, o inserisci 0 per terminare: ");
  string nomeDaInserire = Console.ReadLine();
  if( nomeDaInserire == "0")
    {
        break;  // interrompo il ciclo se scrivo zero 
    }
  nomi.Add(nomeDaInserire); // inserisco il nome nella lista
}

while(nomi.Count > 0)
{
    int indiceCasuale = random.Next(nomi.Count); // genero un indice causale tra 0 e il numero di elementi della lista -1
    string nomeEstratto = nomi[indiceCasuale];

    Console.WriteLine($" Nome estratto: {nomeEstratto}");
    nomi.RemoveAt(indiceCasuale);// rimuove il nome estratto dalla lsita che corrisponde all'indice causale generato

    Console.WriteLine("Vuoi estrarre un altro nome?(y/n)");
    string risposta = Console.ReadLine();

    if(risposta.ToLower() != "y")
    {
        break;
    }
}

