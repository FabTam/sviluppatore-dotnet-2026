/* DIZIONARI E METODI

I dizionari sono collezioni di coppie chiave-valore. La chiave deve essere univoca mentre i valori possono essere duplicati.
I metodi disponibili per manipolare i dizionari sono:
*/

/* METODO ADD
Aggiunge un elemento al dizionario. Se la chiave esiste già, il valore viene aggiornato.
*/

using System.Formats.Asn1;

Dictionary<int,string> dizionario = new Dictionary<int,string>()
{
    {1, "uno"},
    {2, "due"},
    {3, "tre"}
};

dizionario.Add(4, "quattro"); // aggiunge una coppia chiave valore, se la chiave esiste già, il valore deve essere gestito in modo da essere aggiornato.

/*
METODO ContainsKey
Verifica se una chiave esiste nel dizionario
*/

bool esisteChiave = dizionario.ContainsKey(1);// true
 esisteChiave = dizionario.ContainsKey(5);// false


/*
METODO ContainsValue
Verifica se c'è un valore nel dizionario
*/

bool esisteValore = dizionario.ContainsValue("uno");// true
esisteValore = dizionario.ContainsValue("cinque"); // false

/*
METODO TryGetValue
Permette di ottenere il valore associato ad una chiave specifica. Restituisce true se la chiave esiste, altrimenti false.
*/

if(dizionario.TryGetValue(1, out string valore))
{
    Console.WriteLine($"Il valore associato alla chiave 1 è: {valore}");

}
else
{
    Console.WriteLine("La chiave 1 non esiste nel dizionario");
}

/*
METODO Remove
Rimuove un elemento dal dizionario in base alla chiave. Se la chiave non esiste, non viene fatto nulla.
*/

dizionario.Remove(2); // rimuove l'elemento con chiave 2.

/* METODO Clear
Elimina tutti gli elementi del dizionario.
*/

// dizionario.Clear();// dizionario pulito

// ATTIVITA POSSIBILI CON DIZIONARIO:

/* MODIFICA DI UN VALORE GIà ESISTENTE.
  Assegnazione.
*/

dizionario[1] = "uno modificato";// accesso alla chiave 1 del dizionario

/* ACCESSO AD UNA CHIAVE O AD UN VALORE

Come convenzione si usa kvp(Key Value Pair) per accedere alla chiave e al valore di un dizionario

*/

foreach(var kvp in dizionario) // oppure si può utilizzare KeyValuePair<int,string>.
{
    Console.WriteLine($"Chiave: {kvp.Key}, Valore: {kvp.Value}");
}

// DIZIONARIO DI LISTE

/* Un dizionario può contenere come valori anche altre strutture dati, come ad esempio una lista.
*/

Dictionary<int, List<string>> dizionarioListe = new Dictionary<int, List<string>>()
{
    {1, new List<string>{ "nome","prezzo"}},
    {2, new List<string>{"nome"}},
    {3, new List<string>{"nome","quantità"} }

};

// aggiungo un elemento alla lista associata alla chiave 1
dizionarioListe[1].Add("quantità");

foreach(var kvp in dizionarioListe)
{
    Console.WriteLine($"Chiave : {kvp.Key}, Valori: {string.Join(",", kvp.Value)}"); // essendo più valori faccio 
}

// Dizionario di dizionari

Dictionary<int, Dictionary<string,string>> dizionarioDiDizionari = new Dictionary<int, Dictionary<string, string>>
{
    {1, new Dictionary<string, string>{{"nome", "prodotto1"},{"prezzo", "10"}}},
    {2, new Dictionary<string, string>{{"nome", "prodotto2"},{"prezzo", "20"}}},
    {3, new Dictionary<string, string>{{"nome", "prodotto3"},{"prezzo", "30"}}},

};

dizionarioDiDizionari[1].Add("quantità", "100"); // aggiungo un elemento al dizionario associato alla chiave 1

dizionarioDiDizionari.Add(4, new Dictionary<string, string>{{"nome", "prod4"}, {"prezzo", "4"}, {"quantità", "2"}});

foreach(var kvp in dizionarioDiDizionari)
{
    Console.WriteLine($"Chiave: {kvp.Key}"); // stampo le chiavi al primo giro e poi ciclo all'interno sulla chiave
    foreach(var innerKvp in kvp.Value)
    {
        Console.WriteLine($"Chiave: {innerKvp.Key}, Valore : {innerKvp.Value}");
    }
}