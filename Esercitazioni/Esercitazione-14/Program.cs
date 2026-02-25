/*

ESERCITAZIONE:

crea un programma file manager che consenta all'utente di eseguire operazioni sui file e sulle directory. Il programma deve avere le seguenti funzionalità:

- Partire da una cartella chiamata Data all'interno del progetto. X
- deve elencare i file e le sottodirectory presenti nella cartella selezionata. X
- stampare le informazioni su files e cartelle. x
- creare una cartella di backup con il timestamp all'interno della cartella selezionata. x
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
using System.Security.AccessControl;

string percorsoCartella = @".\Data";



string LeggiInput(string messaggio)
{
    Console.WriteLine($"{messaggio}");
    string input = Console.ReadLine();

    return input;
}

void StampaCartelle(string percorso)
{
    if (Directory.Exists(percorso))
    {
        // Stampa tutti i file della cartella corrente
        string[] files = Directory.GetFiles(percorso);
        Console.WriteLine($"[DIR]{Path.GetFileName(percorso)} contiene:");
        foreach (string f in files)
        {
            Console.WriteLine($"[FILE]: {Path.GetFileName(f)}");
        }

        // Per ogni sottocartella, stampala e richiama ricorsivamente
        string[] sottocartelle = Directory.GetDirectories(percorso);
        foreach (string sc in sottocartelle)
        {
            Console.WriteLine($"[CARTELLA]: {Path.GetFileName(sc)}");
            StampaCartelle(sc);  // qui stamperà anche i file di 'sc'
        }
    }
    else
    {
        Console.WriteLine("La cartella non esiste.");
    }
}



void CreaCartellaBackup(string percorsoOrigine, string percorsoDestinazione)
{
    DateTime timeStampCartellaBackup = DateTime.Today;
    string formatoData = timeStampCartellaBackup.ToString("dd_MM_yyyy");
    string percorsobackup = Path.Combine(percorsoDestinazione, $"Backup {formatoData}");
    if (!Directory.Exists(percorsobackup))
    {
        Directory.CreateDirectory(percorsobackup);

        string[] files = Directory.GetFiles(percorsoOrigine);
        foreach (string f in files)
        {
            File.Copy(f, Path.Combine(percorsobackup, Path.GetFileName(f))); // copia i file f nel percorso che combina il path del backup e i nome dei files
        }

        // Per ogni sottocartella, richiama la funzione così che faccia
        string[] sottocartelle = Directory.GetDirectories(percorsoOrigine);
        foreach (string sc in sottocartelle)
        {
            string percorsoBackupSc = Path.Combine(percorsobackup, Path.GetFileName(sc));
            CreaCartellaBackup(sc, percorsoBackupSc);
        }

    }
    else
    {
        Console.WriteLine("La cartella backup è già stata creata.");
        Console.WriteLine(new string('-', 60));
    }
}




StampaCartelle(percorsoCartella);
CreaCartellaBackup(percorsoCartella);
//Ricorsiva();
//string percorsoBackup = CreaCartellaBackup();
// CopiaFile(percorsoCartella, percorsoBackup);

void CopiaFile(string percorsoCartella, string percorsoDestinazione)
{
    if (Directory.Exists(percorsoCartella))
    {


    }
    else
    {
        Console.WriteLine("La directory non esiste.");
    }
    ;

}

void BackupRicorsivo(string directorySelezionata, string currentBackupDirectory)
{
    if (!Directory.Exists(directorySelezionata))
    {
        Console.WriteLine($"Attenzione la cartella {directorySelezionata} non esiste, uscita da Backup()");
        return;
    }

    string[] directories = Directory.GetDirectories(directorySelezionata);
    Console.WriteLine($"Stampa metodo backup, directorySelezionata : {directorySelezionata}  currentBackupDireectory: {currentBackupDirectory}");

    foreach (string currentDirectory in directories)
    {
        string targetPath = Path.Combine(currentBackupDirectory, currentDirectory);
        Directory.CreateDirectory(targetPath);
    }
    BackupRicorsivo(percorsoCartella, currentBackupDirectory);
    //CopyFiles(variabili);

}