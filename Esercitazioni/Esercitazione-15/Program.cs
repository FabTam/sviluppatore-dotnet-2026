
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
      Console.Write("Premi 1 per visualizzare la lista dei partecipanti");
      Console.Write("Premi 2 per inserire un partecipante");
      Console.Write("Premi 3 per modificare un partecipante");
      Console.Write("Premi 4 per eliminare un partecipante");
      Console.Write("Premi 5 per uscire");
      string input = Console.ReadLine();
      // inserire uno switch case
   }


}

string lastIdJson = File.ReadAllText(@"lastId.json");



string LeggiInput(string messaggio)
{
   Console.WriteLine(messaggio);
   string input = Console.ReadLine();

   return input;
}


void StampaListaPartecipanti()
{
   string listaPartecipanti = File.ReadAllText(@"listapartecipanti.json");
   List<dynamic> listaPartecipantiObj = JsonConvert.DeserializeObject<List<dynamic>>(listaPartecipanti);

   Console.WriteLine("Tabella partecipanti");
   Console.WriteLine(new string('-', 60));
   Console.WriteLine("ID\t NOME\t ETA\t PRESENTE\t INTERESSI");
   foreach (var p in listaPartecipantiObj)
   {
      Console.WriteLine($"{p.id} | {p.nome} | {p.eta} |{p.presente} | {string.Join(", ", p.interessi)}");
   }


}

void InserisciPartecipante()
{

   Console.Write("Nome:");
   string nome = Console.ReadLine();
   Console.Write("Età: ");
   int eta = int.Parse(Console.ReadLine());
   Console.Write("Presente(true/false)");
   bool presente = bool.Parse(Console.ReadLine());
   Console.Write("Inserisci gli interessi, se più di uno separali con una virgola:");
   string interesse = Console.ReadLine();
   List<string> interessi = interesse.Split(",").ToList();

   var lastIdObj = JsonConvert.DeserializeObject<dynamic>(lastIdJson);
   lastIdObj.lastId = (int)lastIdObj.lastId + 1;
   string updatedLastId = JsonConvert.SerializeObject(lastIdObj, Formatting.Indented);
   File.WriteAllText(@"lastId.json", updatedLastId);

   var nuovoPartecipante = new
   {
      id = lastIdObj.lastId,
      nome = nome,
      eta = eta,
      presente = presente,
      interessi = interessi,
   };

   //leggo la lista.
   string listaPartecipanti = File.ReadAllText(@"listapartecipanti.json");
   // converto il json in un oggetto lista.
   List<dynamic> listaPartecipantiObj = JsonConvert.DeserializeObject<List<dynamic>>(listaPartecipanti);
   // aggiungo il partecipante all'oggetto lista.
   listaPartecipantiObj.Add(nuovoPartecipante);

   // ora che la lista è stata modificata la converto in un json.
   string listaPartecipantiAggiornata = JsonConvert.SerializeObject(listaPartecipantiObj, Formatting.Indented);

   // riscrivo la lista aggiornata.
   File.WriteAllText(@"listapartecipanti.json", listaPartecipantiAggiornata);


}

EliminaPartecipante();

void ModificaPartecipante()
{
   // Stampo la lista dei partecipanti
   StampaListaPartecipanti();

   Console.Write("Inserisci l'ID del partecipante da modificare: ");
   int id = int.Parse(Console.ReadLine());

   string listapartecipanti = File.ReadAllText(@"listapartecipanti.json");
   List<dynamic> listaPartecipantiDaModificareObj = JsonConvert.DeserializeObject<List<dynamic>>(listapartecipanti);

   for (int i = 0; i < listaPartecipantiDaModificareObj.Count; i++)
   {
      if (id == (int)listaPartecipantiDaModificareObj[i].id)
      {
         string nome = LeggiInput("Modifica il nome: ");
         if (!string.IsNullOrWhiteSpace(nome))
            listaPartecipantiDaModificareObj[i].nome = nome;
         string eta = LeggiInput("Modifica l'età:");
         if (!string.IsNullOrWhiteSpace(eta))
            listaPartecipantiDaModificareObj[i].eta = eta;
         string presente = LeggiInput("Modifica la presenza:");
         if (!string.IsNullOrWhiteSpace(presente))
            listaPartecipantiDaModificareObj[i].presente = presente;
         string interesse = LeggiInput("Modifica gli interessi:");
         string[] interessi = interesse.Split(",");
         if (!string.IsNullOrWhiteSpace(interesse))
            listaPartecipantiDaModificareObj[i].interessi = JArray.FromObject(interessi);

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
      if( listaPartecipantiDaModificareObj[i].id == id)
        listaPartecipantiDaModificareObj.Remove(listaPartecipantiDaModificareObj[i]);
   }
   string listaPartecipantiAggiornata = JsonConvert.SerializeObject(listaPartecipantiDaModificareObj);
   File.WriteAllText(@"listapartecipanti.json", listaPartecipantiAggiornata);
}


