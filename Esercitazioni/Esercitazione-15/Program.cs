


using System.Transactions;
using Newtonsoft.Json;



/*
FILE JSON

i Files json sono files di testo che contengono dati strutturati in un formato leggibile dall'uomo e facilmente interpretabile dalle macchine.
Sono usati per scambiare dati tra applicazioni, ad esempio tra un client e un server.
Gli endpoint cioè le URL a cui un client può inviare richieste per ottenere o inviare dati, spesso restituiscono dati in formato json.

Per noi è importante perchè il corso prevede il backend con un'applicazione dotnet web api che restituisce dati in formato json al frontend fatto con Angular.

I dati in un file json sono organizzati in coppie chiavi-valore, dove la chiave è una stringa e il valore può essere un numero, una stringa, un boooleano,
un array o un oggetto, quindi i tipi di dati vengono rappresentati in modo semplici e intuitivo.



//Esempio di file json
{
    "nome": "Partecipanti1",
     "eta": 30,
     "presente": true
}


 I valori possono essere di diversi tipi, ad esempio stringhe, numeri, booleani, array o oggetti.


// Esempio di file json complesso
{
    "interessi": ["programmazione", "musica", "sport"] // con array
}

{
    {
    "nome": "Partecipanti1",
     "eta": 30,
     "presente": true,
    "interessi": ["programmazione", "musica", "sport"], // con array
    "indirizzo": {
            "via": "Via Roma",
             "Citta" : "Milano",
             "Cap": 20131
        }
    }
}

Oppure un elenco di oggetti json.

Di per se il file json può essere letto senza bisogno di import di librerie, verrebbe letto come una stringa, quindi per poterlo interpretare e manipolare è necessario utilizzare una libreria
che permette di deserializzare il file json in un oggetto C#.

Deserializzare significa convertire una stringa json in un oggetto C# in modo da farlo iventare un oggetto con proprietà e metodi che possiamo utilizzare nel nostro codice, cioè leggerlo.

Serializzare significa convertire un oggetto in una stringa JSON, cioè scriverlo.
Però per farlo abbiamo bisogno di una libreria: noi utilizzeremo Netwtonsoft.Json, popolare in C#.cd

Le librerie sono disponibili tramite package manager di .NET
*/

/* DESERIALIZZARE un file json semplice
   Il metodo JsonConvert.DeserializeObject<T>(string json) permette di deserializzare una stringa json inun oggetto di tipo T, dove T è il tipo di oggetto che vogliamo ottenere.
   Indica un tipo generico, cioè un tipo che viene specificato al momento dell'utilizzo del metodo, in questo caso il tipo è Partecipante che è una classe C# che rappresenta la
   struttura del file json.

   Cioè non sappiamo quali sono i campi del file json, quindi non possiamo creare un oggetto con proprietà speciiche, ma possiamo creare una classe generica che rappresenta la
   struttura del file json, quindi generalmente si usa var per indicare che il tipo è generico.
*/



string path               = @"test.json";
string json               = File.ReadAllText(path); // leggo il contenuto del file json
var partecipante          = JsonConvert.DeserializeObject<dynamic>(json);  // deserializzazione tramite JsonConvert

// una volta deserializzato, posso accedere ai campi dell'oggetto.

Console.WriteLine($"Nome    : {partecipante.nome}");
Console.WriteLine($"Eta     : {partecipante.eta}");
Console.WriteLine($"Presente: {partecipante.presente}");

/*
In questo caso abbbiamo deserializzato il file json in un oggetto dinamico, quindi possiamo accedere ai campi dell'oggetto senza dover creare una rappresentazione dell'oggetto(Classe).
*/

/*
SERIALIZZAZIONE DI UN OGGETTO IN UN FILE JSON
*/

var partecipante1 = new
{
    nome     = "Fabio",
    eta      = 36,
    presente = true,
};

string json1 = JsonConvert.SerializeObject(partecipante1,Formatting.Indented); // serializzo e indento
File.WriteAllText(@"test.json",json1); // scrivo al percorso del file




