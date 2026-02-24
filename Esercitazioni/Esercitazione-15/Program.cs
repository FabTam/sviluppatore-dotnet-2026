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
Però per farlo abbiamo bisogno di una libreria: noi utilizzeremo Netwtonsoft.Json, popolare in C#.
*/