
using Newtonsoft.Json;

// SERIALIZZAZIONE DI UN OGGETTO

string path = @"test.json";
string json = File.ReadAllText(path);

var partecipante = JsonConvert.DeserializeObject<dynamic>(json);

Console.WriteLine("Inserisci un partecipante");
string input = Console.ReadLine();

partecipante.partecipante = input;
partecipante.lastId += 1;
json = JsonConvert.SerializeObject(partecipante, Formatting.Indented);
File.WriteAllText(path, json);

Console.WriteLine($"Nome partecipante inserito: {partecipante.partecipante}");
Console.WriteLine($"Id partecipante: {partecipante.lastId}");
