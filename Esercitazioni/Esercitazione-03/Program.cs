/* ESERCITAZIONE SUI TIPI DI DATI COMPLESSI IN C#
 Creiamo una applicazione console che dichiara un array di 5 numeri interi, li inizializza con valori a scelta e stampa il primo numero dell'array.
 */
using System.Runtime.CompilerServices;

int[] numeri = {1,2,3,4,5};
 Console.WriteLine(numeri[0]); // Inserire un indice fuori dall'array otteniamo un'eccezione.

 // Dichiaro una lista di interi e stampo il primo elemento della lista.

 List<int> interi = new List<int>{10,20,30};
 Console.WriteLine(interi[1]);

// Dichiaro una lista di stringhe vuota e aggiungo 1 nome a scelta, stampando in console il secondo nome della lista e successivamente l'ultimo elemento aggiunto.

List<string> nomi = new List<string>{"Nome1","Nome2", "Nome3"};
Console.WriteLine(nomi[1]);
nomi.Add("Nome4"); // aggiungo un nome alla lista
Console.WriteLine(nomi[3]);

// Dichiaro un dizionario con chiave intero e valore stringa e stampo in console il valore associato alla chiave 2

Dictionary<int, string> dizionario = new Dictionary<int, string>
{
     {1,"Valore1"},
     {2,"Valore2"},
     {3,"Valore3"}
    
};

Console.WriteLine(dizionario[2]);
 