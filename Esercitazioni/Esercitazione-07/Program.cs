// RANDOM, genera i numeri in un intervallo semi aperto
using System.Collections;

Random random = new Random(); // creo una istanza della classe Random, cioè un oggetto "random"

 int numeroCasuale = random.Next(1,101); // genera un numero tra 1 e 100, esclude il massimo.

 int numeroCasualeSenzaMinimo = random.Next(100); // genera un numero tra 0 e 99, 100 numeri.

 double numeroDecimaleCasuale = random.NextDouble(); // genera un numero decimale tra 0,0 e 1,0.

 bool booleanoCasuale = random.Next(2) == 0; // Genera un valore booleano casuale(true o false).

 // esercitazione dado da gioco

 int dado = random.Next(1,7);
 Console.WriteLine($"Hai lanciato il dado e hai ottenuto: {dado}");

 // esercitazione dado versione 2
 Console.WriteLine("Lancia il dado con 1:");
 
while(true)
{
  string input = Console.ReadLine();
  int dado2 = random.Next(1,7);
  if(input == "1")
  {
    Console.WriteLine($"Hai lanciato e hai ottenuto: {dado2}");
  }
  else if( input == "0")
    {
        break;
    }
  else
  {
    Console.WriteLine("Scelta non valida.Riprova");
  }
}
Console.WriteLine("Gioco terminato");

/* esercitazione DADO v3
 lancio per 5 volte, aggiungo i lanci maggiori o uguali a 5, stampo la lista dei lanci
*/
List<int> listaLanci = new List<int>();
int indice = 1;

for(indice = 1; indice <= 5; indice ++)
{
  string input = Console.ReadLine();
  if(input == "1")
  {
    int dado3 = random.Next(1,7);
    Console.WriteLine($"Hai lanciato e hai ottenuto: {dado3}");
    if(dado3 >= 5)
    {
      listaLanci.Add(dado3); // discrimino i lanci minori di 5 per l'aggiunta alla mia lista
    }
  }
 
}
foreach(var lancio in listaLanci)
{
  Console.WriteLine($"Ecco la lista dei lanci: {lancio}"); // itero nella lista e stampo a console i lanci
}