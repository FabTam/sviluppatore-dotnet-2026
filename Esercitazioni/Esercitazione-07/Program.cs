
// ESERCITAZIONE CON CICLO FOREACH

List<int> numeri = new List<int>();

do
{
    Console.Write("Inserisci un numero: "); 
    int inserimento = int.Parse(Console.ReadLine());
    if(inserimento == 0)
    {
        break; // esce dal ciclo
    }
    numeri.Add(inserimento); // aggiungo il numero inserito e ciclo la domanda e l'inserimento fin quando non inserisco 0
}
while(true);

Console.WriteLine("I numeri inseriti sono:");
foreach(var numero in numeri)
{
    Console.Write($"{numero}"); // stampo a console la lista 
}






