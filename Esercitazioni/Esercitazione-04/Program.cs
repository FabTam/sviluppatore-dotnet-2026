// OPERATORI IN C#
int a = 10;
int b = 5;

int somma = a+b;
int modulo = a % b; // torna 0 nel caso non ci sia resto nella divisione tra a e b, torna 1 se c'è un resto

Console.WriteLine($"Questa è la somma: {somma}. Questo è il modulo: {modulo}");

int x = 5;
int y = 10;

bool isEqual = (x == y); // comparazione di valori
Console.WriteLine(isEqual);

// OPERATORI LOGICI

bool c = true;
bool d = false;
bool andResult = c && d; // entrambi i valori devono essere veri o falsi
bool orResult  = c || d; // valuta se uno dei due valori è vero o falso
bool notA      = !c;// inverte il valore del booleano (negazione)

Console.WriteLine($"AND: {andResult}, OR: {orResult}, NOT: {notA}");

// ESERCITAZIONE OPERATORI

//Chiedo all'utente di inserire due numeri interi
Console.WriteLine("Inserisci il primo numero intero:");
int numero1 = int.Parse(Console.ReadLine());
Console.WriteLine("Inserisci il secondo numero intero:");
int numero2 = int.Parse(Console.ReadLine());

Console.WriteLine("Quale operazione vuoi eseguire?");
string operazioneDaEseguire = Console.ReadLine();

bool Somma = operazioneDaEseguire == "Somma";

Console.WriteLine($"La somma è:{numero1 + numero2}");