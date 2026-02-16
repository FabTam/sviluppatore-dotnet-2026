//    ESERCITAZIONE

/*
  - Crea un dizionario che associo ad un numero di telefono un nome ( crealo con qualche dato di default).
  - Permette all'utente di inserire un numero di telefono e un nome e li aggiunge al dizionario.
  - Permette all'utente di modificare il numero di telefono associato al nome.
  - Permette all'utente di eliminare il nome ed il numero di telefono dal dizionario.
  - Nel caso in inserimento di un nome già esistente, il programma chiede se si vuole aggiornare il numero di telefono associato a quel nome.
  - Nel caso di modifica o rimozione il programma deve stampare prima la rubrica così da scegliere il nome da modificare o cancellare.
  - Nel caso di eliminazione di un nome che non esiste, il programma deve stampare un messaggio di errore.

  SUGGERIMENTI
  - per la gestione generale del programma si può usare un while con una variabile booleana che diventa false quanto l'utente sceglie di uscire dal programma
  - per la gestione della rubrica si può usare string string come chiave valore
  - per la gestione dell'input si può normalizzare con i metodi di stringa e convertire il nome con la prima lettera maiuscola usando Textinfo.ToTitleCase()
  - per la stampa possiamo ciclare con un foreach
  - per stampare con un modo ordinato possiamo usare \t per inserire una tabulazione tra il nome e il numero di telefono.
*/

Dictionary<string, string> rubrica = new Dictionary<string, string>()
{
    {"fabio", "3466229087"},
    {"ernesto", "3343345054"},
    {"laura", "335807119"}
};



bool continua = true;

while (continua)
{
    Console.WriteLine("Premi 1 per aggiungere un numero di telefono");
    Console.WriteLine("Premi 2 per modificare");
    Console.WriteLine("Premi 3 per eliminare");
    Console.WriteLine("Premi 4 per visualizzare la rubrica");
    Console.WriteLine("Premi 5 per uscire");
    int input = int.Parse(Console.ReadLine());

    switch (input)
    {
        case 1:

            Console.WriteLine("Digita il numero da inserire");
            string numero = Console.ReadLine();
            Console.WriteLine("Digita il nome da inserire");
            string nome = Console.ReadLine();
            if (rubrica.ContainsKey(numero)) // se contiene la chiave con valore numero
            {
                Console.WriteLine("Il numero inserito è già presente");
            }
            else
            {
                rubrica.Add(numero, nome); // aggiungo il numero e il nome passando i due input come stringhe
            }
            Console.Clear();
            break;


        case 2:

            foreach (var kvp in rubrica)
            {
                Console.WriteLine($"Numero:{kvp.Key} \t Nome: {kvp.Value}"); // stampo per ogni variabile contenuta in rubrica, la chiave e il valore
            }
            Console.WriteLine("Quale numero vuoi modificare?");
            string numerodaMoficare = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo numero");
            string nuovoNumero = Console.ReadLine();
            rubrica[numerodaMoficare] = nuovoNumero; // al contenuto dell'indice di rubrica associo l'input contenuto nella variabile numero.
            Console.Clear();

            break;

        case 3:

            Console.WriteLine($"Quale numero vuoi eliminare?");
            string numerodaEliminare = Console.ReadLine();

            if (rubrica.ContainsKey(numerodaEliminare) == false)
            {
                Console.WriteLine($"Numero non presente");
            }
            else
            {
                Console.WriteLine($"Numero eliminato = {numerodaEliminare}");
            }
            Console.Clear();
            
            break;


        case 4:
            foreach (var kvp in rubrica)
            {
                Console.WriteLine($"Numero:{kvp.Key} \t Nome: {kvp.Value}");
            }
            break;

        case 5:
            continua = false;
            Console.Clear();
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;

    }
}

