
using Newtonsoft.Json;

/* ESERCITAZIONE 3
   Implementazione dell'esercitazione v2 con un file json complesso che contine anche una lista di interessi, quindi il partecipante avrà questa struttura
   {
     
     interessi: ["xx","xx","xx"]}
   Il programma deve chiedere all'utente di inerire anche gli interessi del partecipante, che possono essere inseriti come una stringa separata da virgole
   e poi convertire questa string in una lista di stringhe da salvare nel file json.
   - avere un menu di scelta con le varie opzioni CRUD.
   - deve permettere di visualizzare i partecipanti in mode ordinato
   - deve permettere all'utente di modificare i dati del partecipante
   - permettere di eliminare un partecipante e un elemento dell'elenco degli interessi
   - i partecipanti devono essere aggiunti ad un unico file di partecipanti che contiene una lista di partecipanti
*/

string jsonListaPartecipanti = File.ReadAllText(@"listapartecipanti.json");
List<Contatto> listaPartecipanti = JsonConvert.DeserializeObject<List<Contatto>>(jsonListaPartecipanti);


Menu();



void SalvaLista()
{
   string listaPartecipantiAggiornata = JsonConvert.SerializeObject(listaPartecipanti, Formatting.Indented);
   File.WriteAllText(@"listapartecipanti.json", listaPartecipantiAggiornata);
}

void Menu()
{
   while (true)
   {
      Console.WriteLine("Premi 1 per visualizzare la lista dei partecipanti");
      Console.WriteLine("Premi 2 per inserire un partecipante");
      Console.WriteLine("Premi 3 per modificare un partecipante");
      Console.WriteLine("Premi 4 per modificare gli interessi di un partecipante");
      Console.WriteLine("Premi 5 per eliminare gli interessi di un partecipante");
      Console.WriteLine("Premi 6 per eliminare un partecipante");

      Console.WriteLine("Premi 7 per uscire");
      string input = Console.ReadLine();
      // inserire uno switch case

      switch (input)
      {
         case "1":
            StampaListaPartecipanti();
            break;

         case "2":
            InserisciPartecipante();
            break;

         case "3":
            ModificaPartecipante();
            break;

         case "4":
            ModificaInteressiPartecipante();
            break;

         case "5":
            EliminaInteressePartecipante();
            break;

         case "6":
            EliminaPartecipante();
            break;

         case "7":
            return;

         default:
            Console.WriteLine("Scelta non valida!");
            break;

      }
   }


}

Menu();




string LeggiInput(string messaggio)
{
   Console.WriteLine(messaggio);
   string input = Console.ReadLine();

   return input;
}


void StampaListaPartecipanti()
{
   Console.WriteLine("Tabella partecipanti");
   Console.WriteLine(new string('-', 60));
   Console.WriteLine($"{"ID",-4} {"NOME",-10} {"ETA",-5} {"PRESENTE",-10} {"INTERESSI",-20}");
   foreach (var p in listaPartecipanti)
   {
      Console.WriteLine($"{p.Id,-4}  {p.Nome,-8}  {p.Eta,-5} {p.Presente,-10}  {string.Join(", ", p.Interessi)}");
   }


}

void InserisciPartecipante()
{

   Console.Write("Nome:");
   string nome = Console.ReadLine();
   Console.Write("Età: ");
   string eta = Console.ReadLine();
   Console.Write("Presente(true/false)");
   bool presente = bool.Parse(Console.ReadLine());
   Console.Write("Inserisci gli interessi, se più di uno separali con una virgola:");
   string interesse = Console.ReadLine();
   List<string> interessi = interesse.Split(",").ToList();

   string lastIdJson = File.ReadAllText(@"lastId.json");

   LastId lastIdObj = JsonConvert.DeserializeObject<LastId>(lastIdJson);
   lastIdObj.Id = lastIdObj.Id + 1;
   string updatedLastId = JsonConvert.SerializeObject(lastIdObj, Formatting.Indented);
   File.WriteAllText(@"lastId.json", updatedLastId);

   Contatto nuovoPartecipante = new()
   {
      Id = lastIdObj.Id,
      Nome = nome,
      Eta = eta,
      Presente = presente,
      Interessi = interessi,
   };

   listaPartecipanti.Add(nuovoPartecipante);

   SalvaLista();


}

Contatto ScegliPartecipante()
{
   int scelta = int.Parse(LeggiInput("Inserisci l'id del partecipante:"));

   foreach (var p in listaPartecipanti)
   {
      if (p.Id == scelta)
      {
         Console.WriteLine($"Hai scelto l'id {p.Id}");
         return p;
      }
   }

   Console.WriteLine("Partecipante non trovato");
   return null;
}



void ModificaPartecipante()
{
   // Stampo la lista dei partecipanti
   StampaListaPartecipanti();
   var partecipante = ScegliPartecipante();

   for (int i = 0; i < listaPartecipanti.Count; i++)
   {
      if (partecipante.Id == listaPartecipanti[i].Id)
      {
         string nome = LeggiInput("Modifica il nome: ");
         if (!string.IsNullOrWhiteSpace(nome))
            listaPartecipanti[i].Nome = nome;
         string eta = LeggiInput("Modifica l'età:");
         if (!string.IsNullOrWhiteSpace(eta))
            listaPartecipanti[i].Eta = eta;
         string presente = LeggiInput("Modifica la presenza:");
         if (!string.IsNullOrWhiteSpace(presente))
            listaPartecipanti[i].Presente = bool.Parse(presente);
         string interesse = LeggiInput("Modifica gli interessi:");
         string[] interessi = interesse.Split(",");
         if (!string.IsNullOrWhiteSpace(interesse))
            listaPartecipanti[i].Interessi = interessi.ToList();

      }

   }
   SalvaLista();


}

void EliminaPartecipante()
{
   StampaListaPartecipanti();
   var partecipante = ScegliPartecipante();

   if (partecipante == null)
   {
      Console.WriteLine("Id non presente");
      return;
   }

   listaPartecipanti.Remove(partecipante);

   SalvaLista();

}

void ModificaInteressiPartecipante()
{
   StampaListaPartecipanti();

   var partecipante = ScegliPartecipante();
   if (partecipante == null)
      return;

   partecipante.Interessi = LeggiInput("Inserisci gli interessi separati da virgola:").Split(",").ToList();
   SalvaLista();

}


void EliminaInteressePartecipante()
{
   StampaListaPartecipanti();
   var partecipante = ScegliPartecipante();

   if (partecipante == null)
      return;

   for (int j = 0; j < partecipante.Interessi.Count; j++)
   {
      Console.WriteLine($"{j} - {partecipante.Interessi[j]}");
   }

   int scelta = int.Parse(LeggiInput("Scegli quale interesse eliminare"));

   if (scelta < 0 || scelta >= partecipante.Interessi.Count)
   {
      Console.WriteLine("Indice non valido");
      return;
   }

   partecipante.Interessi.RemoveAt(scelta);

   SalvaLista();

}



public class LastId
{
   public int Id { get; set; }
}

public class Contatto
{
   public int Id { get; set; }
   public string Nome { get; set; }
   public string Eta { get; set; }
   public bool Presente { get; set; }
   public List<string> Interessi { get; set; }
}