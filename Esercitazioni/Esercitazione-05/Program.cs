//GESTIONE DELL'ECCEZIONE
Console.Write("Inserisci il numero da sommare:");

const int NUMERO_PREDEFINITO = 10;
string input = Console.ReadLine();

if(int.TryParse(input, out int numeroUtente))
{
    int risultato = NUMERO_PREDEFINITO + numeroUtente;
    Console.WriteLine($"Questo è il risultato: {risultato}"); // se la conversione ha successo, sommare il numero predefinito.
}
else
{
    Console.WriteLine("ERRORE: l'input inserito non è un numero valido."); // se la conversione fallisce, stampa un messaggio di errore.
}