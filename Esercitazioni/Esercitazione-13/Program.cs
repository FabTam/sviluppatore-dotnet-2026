/* ESERCITAZIONE 3
 Scrivi una funzione che prende in input un numero intero e restituisce il numero solo se è pari, altrimenti restituisce un messaggio di errore.
*/

int PariODispari()
{
    while (true)
    {
        Console.WriteLine("Inserisci un numero");
        string input = Console.ReadLine();
        int numero;
        if (int.TryParse(input, out numero))
        {
            if (numero % 2 == 1)
            {
                Console.WriteLine($"ERROR");
                continue;
            }
            return numero;

        }
        else
         Console.WriteLine("Input non valido.");

    }

}

Console.WriteLine($"L'input inserito è {PariODispari()}");
