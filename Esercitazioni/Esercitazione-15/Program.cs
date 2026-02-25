
using Newtonsoft.Json;


/* DESERIALIZZAZIONE DI UN FILE JSON COMPLESSO(CHIAVE INT VALORE LISTA DI STRINGHE)
   posso accedere agli elementi della lista di stirnghe con un ciclo foreahc o con il metodo stirng.join per stampare tutti gli elementi dlela lista in una sola riga.
*/

string path = @"test.json";
string json = File.ReadAllText(path); // leggo il contenuto del file json
var partecipante = JsonConvert.DeserializeObject<dynamic>(json);

Console.WriteLine($"Interessi : {string.Join(",", partecipante.interessi)}");

