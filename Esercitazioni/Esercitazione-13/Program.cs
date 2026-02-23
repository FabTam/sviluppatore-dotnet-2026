/* ESERCITAZIONE 3
 Implementazione dell'esercitaizone 1 del modulo Metodi Dizionario.
 Nuova versione del programma, invece di associare un nome a un numero di telefono, associamo ad un id univoco
 generato con il random un dizionario che contiene dizionari con il nome, il numero di telefono, l'indirizzo,
 lo stato attivo disattivo (true, false).
 Deve esserci la possibilità di visualizzare la rubrica completa o di visualizzare solo i contatti attivi.

*/



Random random = new Random();

Dictionary<int, Dictionary<string, string>> rubrica = new Dictionary<int, Dictionary<string, string>>
{
    {1, new Dictionary<string, string> {{"nome","Fabio"}, {"numero", "3466229087"}, {"indirizzo", "Via Caffaro 21/12"}, {"status","true"},}},
    {2, new Dictionary<string, string> {{"nome","Martina"}, {"numero", "3466229456"}, {"indirizzo", "Via Giustiniani 6"}, {"status","false"},}},
    {3, new Dictionary<string, string> {{"nome","Sara"}, {"numero", "3464569087"}, {"indirizzo", "Via Acquarone 4"}, {"status","true"},}},


};


MenuRubrica();

void MenuRubrica()
{

    bool continua = true;

    while (continua)
    {
        Console.WriteLine("Premi 1 per aggiungere un contatto nella rubrica");
        Console.WriteLine("Premi 2 per modificare");
        Console.WriteLine("Premi 3 per eliminare");
        Console.WriteLine("Premi 4 per visualizzare la rubrica completa");
        Console.WriteLine("Premi 5 per visualizzare la rubrica dei soli numeri attivi");
        Console.WriteLine("Premi 6 per uscire");

        string comando = LeggiInput("");

        switch (comando)
        {
            case "1":
                Aggiungi();
                break;

            case "2":
                Modifica();
                break;

            case "3":
                Rimuovi();
                break;

            case "4":
                StampaContatti();
                break;

            case "5":
                StampaContattiAttivi();
                break;


            case "6":
                continua = false;
                Console.Clear();
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;

        }



    }
}

string LeggiInput(string messaggio)
{
    Console.WriteLine(messaggio);
    string input = Console.ReadLine().Trim().ToLower();
    Console.Clear();

    return input;
}

void StampaContatti()
{
    Console.Clear();
    Console.WriteLine($"{"ID",-5} {"Nome",-20} {"Numero",-15} {"Indirizzo",-30} {"Stato",-10} ");
    // creo un divisore di 80 - con il costruttore di stringhe
    Console.WriteLine(new string('-', 80));
    // itero nel dizionario e stampo ogni chiave col valore corrispondente
    foreach (var kvp in rubrica)
    {
        Console.WriteLine($"{kvp.Key, -5} {kvp.Value["nome"],-20} {kvp.Value["numero"],-15} {kvp.Value["indirizzo"],-30} {kvp.Value["status"],-10}");
    }

    Console.WriteLine(new string('-', 80));
    Console.WriteLine($"Totale contatti: {rubrica.Count}\n");
}

void StampaContattiAttivi()
{
    Console.Clear();
    Console.WriteLine($"{"ID",-5} {"Nome",-20} {"Numero",-15} {"Indirizzo",-30} ");
    // creo un divisore di 80 - con il costruttore di stringhe
    Console.WriteLine(new string('-', 70));
    // itero nel dizionario e stampo ogni chiave col valore corrispondente
    foreach (var kvp in rubrica)
    {
        if(kvp.Value["status"] == "true")
         Console.WriteLine($"{kvp.Key} {kvp.Value["nome"],-20} {kvp.Value["numero"],-15} {kvp.Value["indirizzo"],-30}");
    }

    Console.WriteLine(new string('-', 70));
    Console.WriteLine($"Totale contatti: {rubrica.Count}\n");
}
void Aggiungi()
{
    string nome      = LeggiInput("Inserisci il contatto da aggiungere:");
    string numero    = LeggiInput("Inserisci il numero da aggiungere:");
    string indirizzo = LeggiInput("Inserisci l'indirizzo da aggiungere:");
    string status    = LeggiInput("Inserisci lo status da aggiungere:");

    int id = random.Next(1, 100);
    if (!rubrica.ContainsKey(id))
    {
        Dictionary<string, string> nuovoContatto = new Dictionary<string, string>
   {
        { "nome", nome },
        { "numero", numero },
        { "indirizzo", indirizzo },
        { "status", status }
    };

        rubrica[id] = nuovoContatto;

    }
    else
        Console.WriteLine("Id già presente");




}
void Modifica()
{
    StampaContatti();

    int contatto = int.Parse(LeggiInput("Inserisci il contatto(ID) da modificare"));
    if (rubrica.ContainsKey(contatto)) // se contiene la chiave
    {
        string nome      = LeggiInput("Inserisci il nome da modificare:");
        string numero    = LeggiInput("Inserisci il numero da modificare:");
        string indirizzo = LeggiInput("Inserisci l'indirizzo da modificare:");
        string status    = LeggiInput("Inserisci lo status da modificare:");

        foreach (var kvp in rubrica)
        {
            if (kvp.Key == contatto)
            {
                if (!string.IsNullOrWhiteSpace(nome))
                    kvp.Value["nome"] = nome;
                if (!string.IsNullOrWhiteSpace(numero))
                    kvp.Value["numero"] = numero;
                if (!string.IsNullOrWhiteSpace(indirizzo))
                    kvp.Value["indirizzo"] = indirizzo;
                if (!string.IsNullOrWhiteSpace(status))
                    kvp.Value["status"] = status;
            }
        }

    }
    else
        Console.WriteLine("Contatto non presente in rubrica.");

}


void Rimuovi()
{
    StampaContatti();
    int contatto = int.Parse(LeggiInput("Inserisci il contatto(ID) da rimuovere:"));
    if (rubrica.ContainsKey(contatto) == false)
    {
        Console.WriteLine($"Numero non presente");
    }
    else
    {
        Console.WriteLine($"Contatto eliminato = {contatto}");
        rubrica.Remove(contatto);
    }


}