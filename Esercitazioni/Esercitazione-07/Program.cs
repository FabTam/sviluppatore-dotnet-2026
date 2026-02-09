
// ESERCITAZIONE CON CICLO FOREACH

List<int> numeri = new List<int>();
Console.Write("Inserisci un numero:");
int inserimento = int.Parse(Console.ReadLine());
numeri.Add(inserimento);
while (inserimento != 0)
{
    Console.Write("Inserisci un numero: "); 
    inserimento = int.Parse(Console.ReadLine());
    numeri.Add(inserimento); // aggiungo il numero inserito e ciclo la domanda e l'inserimento fin quando non inserisco 0
}
foreach(var numero in numeri)
{
    Console.Write($"{numero},"); // stampo a console la lista 
}






