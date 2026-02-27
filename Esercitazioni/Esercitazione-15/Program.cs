
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





void Menu()
{
   while (true)
   {
      Console.WriteLine("Premi 1 per visualizzare la lista dei partecipanti");
      Console.WriteLine("Premi 2 per inserire un partecipante");
      Console.WriteLine("Premi 3 per modificare un partecipante");
      Console.WriteLine("Premi 4 per eliminare un partecipante");
      Console.WriteLine("Premi 5 per uscire");
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
            EliminaPartecipante();
            break;

         case "5": 
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
   string listaPartecipanti = File.ReadAllText(@"listapartecipanti.json");
   List<Contatto> listaPartecipantiObj = JsonConvert.DeserializeObject<List<Contatto>>(listaPartecipanti);

   Console.WriteLine("Tabella partecipanti");
   Console.WriteLine(new string('-', 60));
   Console.WriteLine("ID\t NOME\t ETA\t PRESENTE\t INTERESSI");
   foreach (var p in listaPartecipantiObj)
   {
      Console.WriteLine($"{p.Id} | {p.Nome} | {p.Eta} |{p.Presente} | {string.Join(", ", p.Interessi)}");
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

   //leggo la lista.
   string listaPartecipanti = File.ReadAllText(@"listapartecipanti.json");
   // converto il json in un oggetto lista.
   List<Contatto> listaPartecipantiObj = JsonConvert.DeserializeObject<List<Contatto>>(listaPartecipanti);
   // aggiungo il partecipante all'oggetto lista.
   listaPartecipantiObj.Add(nuovoPartecipante);

   // ora che la lista è stata modificata la converto in un json.
   string listaPartecipantiAggiornata = JsonConvert.SerializeObject(listaPartecipantiObj, Formatting.Indented);

   // riscrivo la lista aggiornata.
   File.WriteAllText(@"listapartecipanti.json", listaPartecipantiAggiornata);


}


void ModificaPartecipante()
{
   // Stampo la lista dei partecipanti
   StampaListaPartecipanti();

   Console.Write("Inserisci l'ID del partecipante da modificare: ");
   int id = int.Parse(Console.ReadLine());

   string listapartecipanti = File.ReadAllText(@"listapartecipanti.json");
   List<Contatto> listaPartecipantiDaModificareObj = JsonConvert.DeserializeObject<List<Contatto>>(listapartecipanti);

   for (int i = 0; i < listaPartecipantiDaModificareObj.Count; i++)
   {
      if (id == listaPartecipantiDaModificareObj[i].Id)
      {
         string nome = LeggiInput("Modifica il nome: ");
         if (!string.IsNullOrWhiteSpace(nome))
            listaPartecipantiDaModificareObj[i].Nome = nome;
         string eta = LeggiInput("Modifica l'età:");
         if (!string.IsNullOrWhiteSpace(eta))
            listaPartecipantiDaModificareObj[i].Eta = eta;
         string presente = LeggiInput("Modifica la presenza:");
         if (!string.IsNullOrWhiteSpace(presente))
            listaPartecipantiDaModificareObj[i].Presente = bool.Parse(presente);
         string interesse = LeggiInput("Modifica gli interessi:");
         string[] interessi = interesse.Split(",");
         if (!string.IsNullOrWhiteSpace(interesse))
            listaPartecipantiDaModificareObj[i].Interessi = interessi.ToList();

      }

   }
   string listaPartecipantiDaModificare = JsonConvert.SerializeObject(listaPartecipantiDaModificareObj, Formatting.Indented);
   File.WriteAllText(@"listapartecipanti.json", listaPartecipantiDaModificare);

}

void EliminaPartecipante()
{
   Console.Write("Inserisci l'ID del partecipante da eliminare: ");
   int id = int.Parse(Console.ReadLine());

   string listapartecipanti = File.ReadAllText(@"listapartecipanti.json");
   List<dynamic> listaPartecipantiDaModificareObj = JsonConvert.DeserializeObject<List<dynamic>>(listapartecipanti);

   for (int i = 0; i < listaPartecipantiDaModificareObj.Count; i++)
   {
      if (listaPartecipantiDaModificareObj[i].id == id)
         listaPartecipantiDaModificareObj.Remove(listaPartecipantiDaModificareObj[i]);
   }
   string listaPartecipantiAggiornata = JsonConvert.SerializeObject(listaPartecipantiDaModificareObj);
   File.WriteAllText(@"listapartecipanti.json", listaPartecipantiAggiornata);
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