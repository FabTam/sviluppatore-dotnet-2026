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
        string[] cartelle = Directory.GetDirectories(percorsoCartella); // divido le cartelle in un array di stringhe

        Console.WriteLine($"[DIR]{percorsoCartella} contiene:");
        foreach (string c in cartelle)
        {

            string nomeCartella = Path.GetFileName(c);
            Console.WriteLine($"[CARTELLA]: {nomeCartella}");

            string[] files = Directory.GetFiles(c); // divido i files presenti nelle cartelle in un array di stringhe
            foreach (string f in files)
            {
                string nomeFile = Path.GetFileName(f);
                Console.WriteLine($"[FILE]:{nomeFile}");


            }

            string[] sottocartelle = Directory.GetDirectories(c);
            foreach (string sc in sottocartelle)
            {

                string nomeSottoCartella = Path.GetFileName(sc);
                Console.WriteLine($"[DIR]: {nomeCartella} [SUBDIR]: {nomeSottoCartella}");
                string[] filesSottoCartella = Directory.GetFiles(sc);
                foreach (string f in filesSottoCartella)
                {
                    string nomeFile = Path.GetFileName(f);
                    Console.WriteLine($"[DIR]: {nomeSottoCartella} [FILE]:{nomeFile}");

                }

            }

        }


    }
    else
    {
        Console.WriteLine("La cartella non esiste.");
    }
}



string CreaCartellaBackup()
{
    DateTime timeStampCartellaBackup = DateTime.Today;
    string formatoData = timeStampCartellaBackup.ToString("dd_MM_yyyy");
    string percorsoBackup = Path.Combine($"Backup {formatoData}");
    if (!Directory.Exists(percorsoBackup))
    {
        Directory.CreateDirectory(percorsoBackup);
        string percorsoTXT = Path.Combine(percorsoBackup, "TXT");
        string percorsoPNG = Path.Combine(percorsoBackup, "PNG");
        string percorsoPDF = Path.Combine(percorsoBackup, "PDF");

        Directory.CreateDirectory(percorsoTXT);
        Directory.CreateDirectory(percorsoPNG);
        Directory.CreateDirectory(percorsoPDF);

    }
    else
    {
        Console.WriteLine("La cartella backup è già stata creata.");
        Console.WriteLine(new string('-', 60));

    }
    return percorsoBackup;
}




string percorsoBackup = CreaCartellaBackup();
// CopiaFile(percorsoCartella, percorsoBackup);

void CopiaFile(string percorsoCartella, string percorsoDestinazione)
{
    if (Directory.Exists(percorsoCartella))
    {
        string[] cartelle = Directory.GetDirectories(percorsoCartella); // divido le cartelle in un array di stringhe
        
        foreach (string c in cartelle)
        {
            string[] files = Directory.GetFiles(c); // divido i files presenti nelle cartelle in un array di stringhe
            foreach (string f in files)
            {
                string estensioneFile = Path.GetExtension(f);
                if(estensioneFile == ".txt")
                {
                    percorsoDestinazione = Path.Combine(percorsoDestinazione, estensioneFile.ToUpper().Replace(".",""));

                }

            }
            string[] sottocartelle = Directory.GetDirectories(c);
            foreach (string sc in sottocartelle)
            {

                string[] filesSottoCartella = Directory.GetFiles(sc);
                foreach (string f in filesSottoCartella)
                {
                    string estensioneFile = Path.GetFileName(f);
                }

            }

        }

    }

    string percorsoIniziale = percorsoCartella;
    string percorsoFinale = percorsoDestinazione;
    if (File.Exists(percorsoIniziale))
    {
        File.Copy(percorsoIniziale, percorsoFinale); // copia il file
    }
    else
        Console.WriteLine("il file di origine non esiste");

}

void BackupRicorsivo(string directorySelezionata, string currentBackupDirectory)
{
    if(!Directory.Exists(directorySelezionata))
    {
        Console.WriteLine($"Attenzione la cartella {directorySelezionata} non esiste, uscita da Backup()");
        return;
    }

    string[] directories = Directory.GetDirectories(directorySelezionata);
    Console.WriteLine($"Stampa metodo backup, directorySelezionata : {directorySelezionata}  currentBackupDireectory: {currentBackupDirectory}");

    foreach( string currentDirectory in directories)
    {
        string targetPath = Path.Combine(currentBackupDirectory, currentDirectory);
        Directory.CreateDirectory(targetPath);
    }
    BackupRicorsivo(percorsoCartella,currentBackupDirectory);
    //CopyFiles(variabili);

}