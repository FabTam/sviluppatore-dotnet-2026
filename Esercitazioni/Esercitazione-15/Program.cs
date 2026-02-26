
using Newtonsoft.Json;

/* ESERCITAZIONE 1
 - Programma che usa un file json come metodo di persistenza dell'id dell'ultimo partecipante creato, in modo da poterlo incrementare ad ogni creazione di un nuovo partecipante.
 
 - Crea un file json chiamato lastId.json con 
 {
    "lastId" : 0
 }

 Dizionario int string dove la chiave è lastId e il valore è un int.
 

 - L'applicazione legge il file json
 - deserializza il contenuto in un oggetto
 - incrementa il valore di lastId
 - serializza l'oggetto aggiornato
 - lo scriverà nuovamente sul file
*/


string path = @"lastId.json";
string json = File.ReadAllText(path);

var partecipante = JsonConvert.DeserializeObject<dynamic>(json);

Console.WriteLine("Inserisci un partecipante");
string input = Console.ReadLine();

partecipante.partecipante = input;
partecipante.lastId += 1;
json = JsonConvert.SerializeObject(partecipante, Formatting.Indented);
File.WriteAllText(path, json);

Console.WriteLine($"Nome partecipante inserito: {partecipante.partecipante}");
Console.WriteLine($"Id ultimo partecipante inserito: {partecipante.lastId}");
