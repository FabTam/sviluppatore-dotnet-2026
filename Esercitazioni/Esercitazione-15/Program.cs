
using Newtonsoft.Json;

/* ESERCITAZIONE 2
   - Legge i dati inseriti da un utente
   - crea l'oggetto con i dati inseriti dall'utente
   - salva il file in un partecipante json
*/



string lastIdJson = File.ReadAllText(@"lastId.json");

Console.Write("Nome:");
string nome = Console.ReadLine();
Console.Write("Età: ");
int eta = int.Parse(Console.ReadLine());
Console.Write("Presente(true/false)");
bool presente = bool.Parse(Console.ReadLine());

// costruisco l'oggetto partecipante con i dati inseriti dall'utente

var nuovoPartecipante = new
{
   id = JsonConvert.DeserializeObject<dynamic>(lastIdJson).lastId +1,
   nome = nome,
   eta = eta,
   presente = presente
};

// serializzo
string nuovoPartecipanteJson = JsonConvert.SerializeObject(nuovoPartecipante, Formatting.Indented);
// scrivo su un file json
File.WriteAllText(@"partecipante.json", nuovoPartecipanteJson);
//aggiorno il valore di last id
var lastIdObj = JsonConvert.DeserializeObject<dynamic>(lastIdJson);
lastIdObj.lastId = (int)lastIdObj.lastId +1;
// serializzo l'oggetto aggiornato
string updatedLastIdJson = JsonConvert.SerializeObject(lastIdObj, Formatting.Indented);
// scrivo la stringa json aggiornata su un file
File.WriteAllText(@"lastId.json", updatedLastIdJson);