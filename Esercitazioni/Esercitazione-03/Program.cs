/* ESERCITAZIONE SUI TIPI DI DATI COMPLESSI IN C# E PARSE
 Creiamo una applicazione console che dichiara un array di 5 numeri interi, li inizializza con valori a scelta e stampa il primo numero dell'array.
 */
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

// Dichiaro un dizionario con chiave stringa e valore intero.Aggiungo al dizionario 3 coppie chiave-valore a scelta e stampo in console il valore associato alla chiave "Due"
 Dictionary<string,int> dizionario2 = new Dictionary<string, int>();
 
 dizionario2.Add("Uno",1);
 dizionario2.Add("Due",2);
 dizionario2.Add("Tre",3);

 Console.WriteLine(dizionario2["Due"]);

// Dichiaro una lista con aggiunta di un elemento tramite input utente da console
List<string> utenti = new List<string>();
Console.Write("Scrivi il nome dell'utente da aggiungere alla lista:");
string nuovoUtente1 = Console.ReadLine();
utenti.Add(nuovoUtente1); // aggiungo un nome alla lista

Console.Write("Scrivi il nome dell'utente da aggiungere alla lista:");
string nuovoUtente2 = Console.ReadLine();
utenti.Add(nuovoUtente2); // aggiungo un nome alla lista

Console.Write("Scrivi il nome dell'utente da aggiungere alla lista:");
string nuovoUtente3 = Console.ReadLine();
utenti.Add(nuovoUtente3); // aggiungo un nome alla lista

Console.Write("Quale nome vuoi stampare?1, 2 o 3?");
string nomeDaStampare = Console.ReadLine();
int indice = int.Parse(nomeDaStampare) -1;
Console.WriteLine($"Il nome da stampare è : {utenti[indice]})");

Console.WriteLine($"il tipo di dato è: {nomeDaStampare.GetType()}");

Console.WriteLine("Inserisci un numero decimale:");
string input = Console.ReadLine();
double numeroDecimale = double.Parse(input); // Conversione da stringa a double
Console.WriteLine($"Il numero inserito è: {numeroDecimale}");

numeroDecimale = 9.99;
int numeroIntero = (int)numeroDecimale; // casting in cui la parte decimale viene troncata
Console.WriteLine($"Il numero intero è: {numeroIntero}");