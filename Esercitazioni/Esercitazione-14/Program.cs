/*

ESERCITAZIONE:

crea un programma file manager che consenta all'utente di eseguire operazioni sui file e sulle directory. Il programma deve avere le seguenti funzionalità:

- Partire da una cartella chiamata Data all'interno del progetto. X
- fare selezionare una cartella all'utente inserendo un percorso relativo. X
- deve elencare i file e le sottodirectory presenti nella cartella selezionata. x
- stampare le informazioni su files e cartelle.
- creare una cartella di backup con il timestamp all'interno della cartella selezionata.
- Copiare tutti i file presenti nella cartella selezionata, mantenendo la struttura delle sottocartelle.
- Deve spostare i files copiati dentro le cartelle divise per estensione ( una cartella per estensione).
- Deve eliminare i file originali dopo averli copiati.
- Deve gestire eventuali errori ( percorso non valido o file in uso).

- SUGGERIMENTI : crea manualmente una struttura di cartelle e file per testare il programma.
Struttura di esempio:

Progetto -> Cartella 1 - Cartella 2
Cartella 1 -> file.txt - Cartella 3
Cartella 2 -> file.png
Cartella 3 -> file.jpg


*/
string percorsoCartella = @".\Data";



string LeggiInput(string messaggio)
{
    Console.WriteLine($"{messaggio}");
    string input = Console.ReadLine();

    return input;
}

void StampaCartelle()
{
    if (Directory.Exists(percorsoCartella))
    {
        string[] cartelle = Directory.GetDirectories(percorsoCartella);

        foreach (string c in cartelle)
        {
            Console.WriteLine($"Queste sono le cartelle contenute in Data: {c}");
            string nomeFile = Path.GetFileName(c);
            Console.WriteLine($"Questi sono i file contenuti nelle cartella {c} : {nomeFile}");
            string[] sottocartelle = Directory.GetDirectories(c);
            foreach (string sc in sottocartelle)
            {
                string nomeFileSottoCartella = Path.GetFileName(sc);
                Console.WriteLine($"Questo è il percorso delle sottocartelle: {sc}");
                Console.WriteLine($"Questi sono i file contenuti nelle cartella {sc} : {nomeFileSottoCartella}");
            }

        }

    }
    else
    {
        Console.WriteLine("La cartella non esiste.");
    }
}

void SelezionaCartella()
{

    StampaCartelle();
    string nomeCartella = LeggiInput("Quale cartella vuoi selezionare? Inserisci il nome:");

    string[] cartelle = Directory.GetDirectories(percorsoCartella);
    bool cartellaTrovata = false;

    for (int i = 0; i < cartelle.Length && !cartellaTrovata; i++)
    {
        if (nomeCartella == Path.GetFileName(cartelle[i]))
        {
            cartellaTrovata = true;
            percorsoCartella = cartelle[i];
            Console.WriteLine($"Hai selezionato la cartella: {percorsoCartella}");
            break;
        }

        string[] sottocartelle = Directory.GetDirectories(cartelle[i]);

        for (int j = 0; j < sottocartelle.Length && !cartellaTrovata; j++)
        {
            if (nomeCartella == Path.GetFileName(sottocartelle[j]))
            {
                cartellaTrovata = true;
                percorsoCartella = sottocartelle[j];
                Console.WriteLine($"Hai selezionato la cartella: {percorsoCartella}");
                break;
            }
        }
    }

    if (!cartellaTrovata)
    {
        Console.WriteLine("Cartella non presente.");
    }
}

void CreaCartellaBackup()
{
    DateTime timeStampCartellaBackup = DateTime.Today;
    timeStampCartellaBackup.ToString("dd,MM,yy");
    string percorsoBackup =  Path.Combine(percorsoCartella, $"Backup {timeStampCartellaBackup}");
    Directory.CreateDirectory(percorsoBackup);
    Console.WriteLine(percorsoBackup);
}



//SelezionaCartella();
CreaCartellaBackup();