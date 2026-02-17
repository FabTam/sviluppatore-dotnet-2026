/*
 Gestione delle date
 Le date dipendono dalla localizzazione del sistema operativo, quindi è importante considerare il fuso orario e le impostazioni locali quando si lavora
 con le date.
*/

DateTime birthDate = new DateTime(1990, 11, 1); // il costruttore di DateTime accetta tre parametri: anno, mese, giorno.
Console.WriteLine($"Sei nato il {birthDate}");

// Conversione di date

DateTime today = DateTime.Today; // Oggi.
Console.WriteLine($"Oggi è {today}");
Console.WriteLine($"Oggi è {today.ToShortDateString()}");
Console.WriteLine($"Oggi è {today.ToLongDateString()}");
Console.WriteLine($"Oggi è {today.ToString("dd/MM/yyyy")}");

/*
. dd indica il giorno a due cifre
. MM il mese a due cifre
. yyyy l'anno a quattro cifre
*/

Console.WriteLine($"Oggi è {today.ToString("dddd/MMMM/yyyy")}"); // ritorna una stringa con giorno mese e anno scritti per esteso.

// PARSE  

string dateString = "2024-12-31"; // data in formato stringa.
DateTime date = DateTime.Parse(dateString);// converte la stringa in un oggetto DateTime.
Console.WriteLine($"La data convertita è : {date}");

// TryParse restituisce true se la conversione è riuscita, altrimenti restituisce false. Il risultato della conversione è restituito dal parametro out


if (DateTime.TryParse(dateString, out DateTime data))
{
    Console.WriteLine($"La data convertita è : {data}");

}
else
{
    Console.WriteLine("La conversione della data non è riuscita");
}


// TIME STAMP

/*
 Molto spesso è utile generare un timestamp, ovvero un numero che rappresenta il numero di secondi trascorsi dal 1 gennaio 1970(Epoch Time)
*/

DateTimeOffset now = DateTimeOffset.UtcNow;
long timestamp = now.ToUnixTimeSeconds();
Console.WriteLine($"Il timestamp attuale è: {timestamp}");


// OPERAZIONI CON LE DATE

// SOMMA

DateTime domani = today.AddDays(1);
Console.WriteLine($"Domani è: {domani}");

DateTime ieri = today.AddDays(-1);
Console.WriteLine($"Ieri era : {ieri:dddd}");

/*
Timespan indica un intervallo di tempo. Ad esempio, possiamo creare un TimeSpan di 2 giorni e sommarlo ad una data.
*/

TimeSpan timeSpan = new TimeSpan(2, 0, 0, 0);//2 giorni

DateTime traDueGiorni = today.Add(timeSpan);
Console.WriteLine($"Tra due giorni sarà: {traDueGiorni}");

/*
 Compare
 Fra il confronto fra due date, restituendo un valore negativo se la prima data è precedente alla seconda, zero se sono uguali e un valore positivo
 se la prima data è successiva alla seconda.
*/

DateTime data3 = today.AddDays(1);
int result = DateTime.Compare(today, domani);

if (result < 0)
{
    Console.WriteLine("La prima data è precedente alla seconda");

}
else if (result == 0)
{
    Console.WriteLine("Le due date sono uguali");

}
else
{
    Console.WriteLine("la prima data è successiva alla seconda");
}

/*
ESERCITAZIONE
 Gestione della scadenza di prodotti deperibili
 Programma che:
 - parte con 3 prodotti di default.
 - chiede all'utente di inserire il nome di un prodotto(ad un dizionario) e la sua data di scadenza (due input?)
 - Calcola quanti giorni mancano alla scadenza del prodotto
 - Stampa una indicazione a fianco al prodotto che indica se il prodotto è scaduto, sta per scadere(entro 3 giorni) o è ancora vendibile.
 - Stampa la data di scadenza in un formato leggibile( 31 dicembre 2024) scritta fra parentesi.
 - Il programma impedisce l'inserimento di prodotti con date di scadenza già passate.
 - il programma consente di visualizzare solo i prodotti che stanno per scadere entro 3 giorni
 - implementazione di un menù che consente di visualizzare tutti i prodotti o solo quelli in scadenza entro 3 giorni o quelli scaduti

*/

Dictionary<string, string> listaProdotti = new Dictionary<string, string>()
{
    {"shampoo", "15/01/2026"},
    {"yogurt","17/02/2026"},
    {"macinato di carne bovina","22/02/2026"}
};

bool valido = false;
while (!valido)
{
    Console.WriteLine("Digita 1 se vuoi aggiungere un prodotto");
    Console.WriteLine("Digita 2 se vuoi visualizzare tutti i prodotti");
    Console.WriteLine("Digita 3 se vuoi visualizzare in prodotti in scadenza entro 3 giorni");
    Console.WriteLine("Digita 4 se vuoi visualizzare i prodotti scaduti");
    Console.WriteLine("Digita 5 se vuoi uscire");

    int input = int.Parse(Console.ReadLine());

    switch (input)
    {
        case 1:
            Console.WriteLine("Inserisci il nome del prodotto da aggiungere:");
            string prodotto = Console.ReadLine();


            if (listaProdotti.ContainsKey(prodotto))
            {
                Console.WriteLine("Prodotto già inserito");
                break;
            }
            Console.WriteLine("Inserisci la data di scadenza nel formato gg/mm/aa");
            string dataScadenzastringa = Console.ReadLine();

            if (DateTime.TryParse(dataScadenzastringa, out DateTime dataScadenza))
            {

                if (dataScadenza < DateTime.Today)
                {
                    Console.WriteLine("Non puoi inserire un prodotto con data di scadenza già passata.");
                }
                else
                {
                    listaProdotti.Add(prodotto, dataScadenza.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Prodotto aggiunto correttamente.");
                }
            }
            else
            {
                Console.WriteLine("Conversione non riuscita;");
            }
            break;

        case 2:
            foreach (var kvp in listaProdotti)
            {
                if (DateTime.TryParse(kvp.Value, out DateTime dataScadenzaProdotto))
                {

                    TimeSpan giorniRimamenti = dataScadenzaProdotto - DateTime.Today;
                    if (giorniRimamenti.Days >= 0 && giorniRimamenti.Days <= 3)
                    {
                        Console.WriteLine($"!PRODOTTO IN SCADENZA! Prodotto: {kvp.Key}, Scade il: {dataScadenzaProdotto:dddd/MMMM/yyyy}");
                    }
                    else if (giorniRimamenti.Days <= 0)
                    {
                        Console.WriteLine($"!PRODOTTO SCADUTO! Prodotto: {kvp.Key}, Scade il: {dataScadenzaProdotto:dddd/MMMM/yyyy}");

                    }
                    else if (giorniRimamenti.Days >= 0)
                    {
                        Console.WriteLine($" Prodotto: {kvp.Key}, Scade il: {dataScadenzaProdotto:dddd/MMMM/yyyy}");

                    }
                }
            }
            break;
        case 3:

            foreach (var kvp in listaProdotti)
                if (DateTime.TryParse(kvp.Value, out DateTime dataScadenzaProdotto))
                {
                    TimeSpan giorniRimamenti = dataScadenzaProdotto - DateTime.Today;
                    if (giorniRimamenti.Days >= 0 && giorniRimamenti.Days <= 3)
                    {
                        Console.WriteLine($"Prodotto: {kvp.Key}, Scade il: {dataScadenzaProdotto:dd/MM/yyyy}");
                    }
                }

            break;
        case 4:
            foreach (var kvp in listaProdotti)
                if (DateTime.TryParse(kvp.Value, out DateTime dataScadenzaProdotto))
                {
                    TimeSpan giorniRimamenti = dataScadenzaProdotto - DateTime.Today;
                    if (giorniRimamenti.Days <= 0)
                    {
                        Console.WriteLine($"Prodotto: {kvp.Key}, Scaduto il: {dataScadenzaProdotto:dd/MM/yyyy}");
                    }
                }
            break;
        case 5:
            valido = true;
            break;
        default:
            valido = true;

            break;


    }
}
