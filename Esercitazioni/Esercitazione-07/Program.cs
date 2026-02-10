/*
Chiede all'utente di lanciare un dado per 5 volte(premendo 1 come prima)
Dopo ogni lancio chiede all'utente se vuole tenere il risultato del lancio(premendo 1 per tenere e 0 per scartare)
aggiunge ad una lista i risultati dei lanci tenuti
stampa la lista dei risultati tenuti e la somma dei punteggi 
*/

Random random = new Random();
List<int> lanciTenuti = new List<int>();
int somma = 0;

for(int i = 1; i <= 5; i++)
{
  Console.WriteLine("Premi 1 per lanciare il dado: ");
  string inputLancio = Console.ReadLine();
  int dado = random.Next(1,7);
  Console.WriteLine("Vuoi tenere il lancio? premi 1 per tenere, 0 per scartare ");
  string inputCollettore = Console.ReadLine();

  if(inputCollettore == "1")
  {
    Console.WriteLine($"Hai lanciato il dado e hai ottenuto: {dado}");
    lanciTenuti.Add(dado);
    
  }
  else if(inputCollettore == "0")
  {
    Console.WriteLine("Lancio scartato");
  }
  else
  {
    Console.WriteLine("Comando non riconosciuto");
  }
}
  
foreach(var lancio in lanciTenuti)
  {
   
   Console.WriteLine($"La lista dei risultati ottenuti è:{lancio}");
   somma += lancio;

  }
Console.Write($"La somma dei lanci tenuti è: {somma}");  
