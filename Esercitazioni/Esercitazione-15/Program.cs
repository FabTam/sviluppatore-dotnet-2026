
using Newtonsoft.Json;

// SERIALIZZAZIONE DI UN OGGETTO

var partecipante = new
{
    nome = "Partecipante1",
    eta = 30,
    presente = true,
    interessi = new List<string> {"programmazione", "musica", "sport"}

};

string json = JsonConvert.SerializeObject(partecipante, Formatting.Indented);
File.WriteAllText(@"test.json",json);