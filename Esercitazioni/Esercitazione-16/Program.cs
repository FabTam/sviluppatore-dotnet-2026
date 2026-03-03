/* Classi Modello


public class Contatto
{
  public int Id{get;set;}
  public string Nome{get;set;}
  ecc ecc
}

Public è un access modifier che indica che la classe è accessibile da qualsiasi parte del codice.
Get e set sono i metodi di accesso che permettono di leggere e scrivere i valori delle proprietà della classe.

Creare un oggetto vuol dire creare una istanza di una determinata classe.
Per convenzione si usa la maiuscola per il nome e le proprietà di una classe.

Vantaggi nell'utilizzo di classi modello:
- Niente errori "strani" con Newtosoft.
- Errori scoperti prima (a compilazione).
- Codice più leggibile e mantenibile.
- Refactoring facile.
- IntelliSense migliore.
*/

// DESERIALIZZAZIONE DI UN FILE JSON CON UNA CLASSE MODELLO.


using System.Dynamic;
using Newtonsoft.Json;

string pathContatto = @"contatti.json";
string pathId = @"lastId.json";
string jsonContatto = File.ReadAllText(pathContatto);
string jsonLastId   = File.ReadAllText(pathId);

// deserializzazione
LastId lastid           = JsonConvert.DeserializeObject<LastId>(jsonLastId);
List<Contatto> contatti = JsonConvert.DeserializeObject<List<Contatto>>(jsonContatto);

Console.WriteLine($"Lastid: {lastid}");
foreach( var contatto in contatti)
{
    Console.WriteLine($"Nome: {contatto.Nome}");
    Console.WriteLine($"Nome: {contatto.Cognome}");
    Console.WriteLine($"Nome: {contatto.Telefono}");
    Console.WriteLine($"Nome: {contatto.Presente}");
    foreach(var interesse in contatto.Interessi)
    {
        Console.WriteLine($" -{interesse}");
    }
}
public class LastId
{
    public int Id { get; set; }
}

public class Contatto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; }
    public bool Presente { get; set; }
    public List<string> Interessi { get; set; }
}

/*
CLASSI STATICHE

Classi che non possono essere istanziate e contengono solo membri statici.
Sono utili soprattutto quando si vuole creare una classe che fornisce funzionalità comuni o utility, come ad esempio una classe che gestisce la lettura e la scritura di file JSON.
Non c'è necessità di istanziare la classe, basta chiamare il metodo della classe:

Public static int nextGenId
{
   // blocco di codice
}

Classe.nextGenId();
*/

// Esempio di classe statica, senza costruttore visto che non deve essere istanziata.

public static class JsonHelper
{
    public static void Salva(string path, object obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static T Leggi<T>(string path)
    {
        // T è un tipo di dato  generico che può essere qualsiasi tipo di dato
        
        if(!File.Exists(path))
        {
            return default(T);
        }

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json);
    }


}
