// ESERCITAZIONE 2

/*
 - Scrivi una funzione tipo string che si comporta come un ReadLine avanzato che implementa la validazione dell'input verificando che 
 non sia vuoto, che non contenga solo spazi bianchi e che non converta l'input in minuscolo:

 - trim : rimuove gli spazi bianchi all'inizio e alla fine 
 - isNullOrEmpty: verifica se la stringa è null o vuota
 - toLower : converte la stringa in minuscolo
*/

string PulisciStringa()
{

    string stringa;
    while(true)
    {
        stringa = Console.ReadLine();
        stringa = stringa.Trim();
        if(!string.IsNullOrEmpty(stringa))
        {
            return stringa.ToLower();
        }
        Console.WriteLine($"Input non valido");
    }
    
}

string input = PulisciStringa();
Console.WriteLine($"{input}");