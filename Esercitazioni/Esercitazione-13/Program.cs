/* ESERCITAZIONE 3
 Implementazione dell'esercitaizone 1 del modulo Metodi Dizionario.


*/




Dictionary<string, string> rubrica = new Dictionary<string, string>()
{
    {"fabio", "3466229087"},
    {"ernesto", "3343345054"},
    {"laura", "335807119"}
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
        Console.WriteLine("Premi 4 per visualizzare la rubrica");
        Console.WriteLine("Premi 5 per uscire");

        string comando = LeggiInput("");
       
            switch (comando)
            {
                case "1":
                    Aggiungi();
                    break;

                case "2":
                    Stampa(rubrica);
                    Modifica();
                    break;

                case "3":
                    Rimuovi();
                    break;


                case "4":
                    Stampa(rubrica);
                    break;

                case "5":
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
    string input = Console.ReadLine().Trim();
    Console.Clear();

    return input;
}

void Stampa(Dictionary<string, string> rubrica)
{
    // itero nel dizionario e stampo ogni chiave col valore corrispondente
    foreach (var kvp in rubrica)
    {
        Console.WriteLine($"Nome:{kvp.Key} \t Numero: {kvp.Value}");

    }
}

void Aggiungi()
{
    string nome = LeggiInput("Inserisci il contatto da aggiungere:");
    string numero = LeggiInput("Inserisci il numero da aggiungere:");

    if (rubrica.ContainsKey(nome)) // se contiene la chiave con valore numero
    {
        Console.WriteLine("Il nome inserito è già presente");
    }
    else
    {
        rubrica.Add(nome, numero); // aggiungo il numero e il nome passando i due input come stringhe
    }

}

void Modifica()
{
    string contatto = LeggiInput("Inserisci il contatto da modificare");
    if (rubrica.ContainsKey(contatto)) // se contiene la chiave
    {
        Console.WriteLine("Il nome inserito è già presente");

    }
    else
    {
        
        string nuovoNumero = LeggiInput("Inserisci il nuovo numero:");
        rubrica[contatto] = nuovoNumero; // al contenuto dell'indice di rubrica associo l'input contenuto nella variabile numero.
        Console.Clear();
    }
}

void Rimuovi()
{
    string contatto = LeggiInput("Inserisci il contatto da rimuovere:");
    if (rubrica.ContainsKey(contatto) == false)
    {
        Console.WriteLine($"Numero non presente");
    }
    else
    {
        rubrica.Remove(contatto);
        Console.WriteLine($"Contatto eliminato = {contatto}");
    }


}