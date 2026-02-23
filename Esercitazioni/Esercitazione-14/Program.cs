/*
METODI FILES E FOLDERS
*/

/*PATH (PERCORSO)

 Il percorso di files e folders può essere assoluto o relativo. Un percorso assoluto specifica la posizione completa del file o della diretory a partire
 dalla radice del file system, mentre un percorso relativo specifica la posizione rispetto alla directory di lavoro corrente dell'applicazione.
*/

string asbolutePath = @"C:\Users\Username\Document\file.txt"; // percorso assoluto

string relativePath = @"..\..\file.txt"; // percorso relativo


// Ottenere un file da un percoso

string fileName                 = Path.GetFileName(relativePath); // Restituisce file.txt.

string cartella                 = Path.GetDirectoryName(relativePath); // restituisce il percorso della cartella.

string extension                = Path.GetExtension(relativePath); // restituisce l'estensione del file nel percorso (".txt").

string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(relativePath); // restituisce il nome del file sena estensione.


// combinare percorsi

string combinedPath = Path.Combine("C:\\Users", "Username", "Documents", "file.txt");

Console.WriteLine(combinedPath); // Per fare scrivere un backslash devo scriverne due, in modo tale ch ecapisca che è una rotta iniziale.

// METODI FILES.

/* Per potere scrivere su un file abbiamo due metodi principali:

   - File.WriteAllText(path, content) che scrive tutto il testo in un file, sosvrascrivendo il contenuto precedente se il file esiste già.
   - File.AppenAllText(path, content) aggiunge del testo alla fine di un file esistente, senza sovrascrivere il contenuto precedente.

   SE IL FILE NON ESISTE VIENE CREATO


   IMPORTANTE: BISOGNA FARE SEMPRE RIFERIMENTO A FILES E FOLDER CONTENUTI ALL'INTERNO DEL PROGETTO, EVITANDO DI ACCEDERE A PERCORSI ESTERNI CHE POTREBBERO NON ESSERE ACCESSIBILI
   O POTREBBERO CAUSARE PROBLEMI DI SICUREZZA.
   UTILIZZA SEMPRE FILE.EXISTS E DIRECTORY.EXISTS PER LE ECCEZIONI.

*/

// creazione di un File.

string path = @"test.txt";
File.WriteAllText(path, "Hello World"); // apre il file e ci scrive dentro.

// lettura di un file.
if(File.Exists(path))
{
    string content = File.ReadAllText(path);
    Console.WriteLine(content);
}
else
{
    Console.WriteLine("Il file non esiste.");
}

//eliminazione di un file.

if(File.Exists(path))
{
   File.Delete(path);
}
else
{
    Console.WriteLine("Il file non esiste.");
}

// copiare un file.

string sourcepath      = @"source.txt";
string destinationPath = @"destinazione.txt";

if(File.Exists(sourcepath))
{
   File.Copy(sourcepath, destinationPath); // copia il file
}
else
{
    Console.WriteLine("Il file di origine non esiste.");
}

// rinominare un file.

string oldFileName  = @"oldname.txt";
string newFileName  = @"newname.txt";

if(File.Exists(oldFileName))
{
    File.Move(oldFileName, newFileName); // rinomina il file
}
else
{
    Console.WriteLine("Il file da rinominare non esiste.");
}

// ottenere informazioni su un file.

FileInfo info = new FileInfo(path);
Console.WriteLine(info.Length);// dimensione del file in byte.
Console.WriteLine(info.CreationTime); // data di creazione del file.
Console.WriteLine(info.LastWriteTime); // data dell'ultima modifica del file.
Console.WriteLine(info.Extension); // estensione del file
Console.WriteLine(info.Name); // nome del file con estensione
Console.WriteLine(info.DirectoryName); // percorso della directory che contiene il file.


// possiamo aggiungere strutture di informazioni tipo elenchi.

List<string> Lines = new List<string> {"Linea 1", "Linea 2", "Linea3"};
File.WriteAllLines( path, Lines); // scrive tutte le righe nel file, sosvrascrivendo se esiste già.
File.AppendAllLines(path, Lines); // Aggiunge tutte le righe alla fine del file, senza sosvrascrivere il contenuto precedente.

// posso anche leggere un file riga per riga, ottenendo un array di stringhe

string [] lines = File.ReadAllLines(path);// Legge tutte le ringhe del file e le restituisce come array di stringhe.

foreach( string l in lines)
{
    Console.WriteLine(l); // Stampa ogni riga del file.
}



// METODI FOLDERS



// Creazione cartella.

string directory = @"test";
Directory.CreateDirectory(directory); // creazione di una cartella

// verifica dell'esistenza di una directory.

if(Directory.Exists(directory));
{
    Console.WriteLine( "Directory exists");
}

// Eliminare una directory.

if(Directory.Exists(directory))

 Directory.Delete(directory);

else
{
    Console.WriteLine("La cartalla non esiste");
}


// copiare una directory.

string sourceDir = @"sourceDir";

string destinationDir = @"destinationDir";

if(Directory.Exists(sourceDir))
{
   // DirectoryCopy(sourceDir, destinationDir, true); Copia la directory e tutto il suo contenuto, sovrascrivendo se esiste già, il tutto gestito da una funzione creata ad hoc.

}
else
Console.WriteLine("La directory di origine non esiste");


// Elencare i file in una directory.

if(Directory.Exists(directory))
{
    string [] files = Directory.GetFiles(directory); // ottiene un array di stringhe con i percorsi dei file nella directory
    foreach(string f in files)
    {
        Console.WriteLine(f); // stampa il PERCORSO di ogni file
    }
}
else
Console.WriteLine("La directory non esiste");


// Elencare le sottocartelle in una cartella.

if(Directory.Exists(directory))
{
    string [] directories = Directory.GetDirectories(directory); // ottiene un array di stringhe con i percorsi delle cartelle nella directory
    foreach(string d in directories)
    {
        Console.WriteLine(d); // stampa il PERCORSO di ogni cartella contenuta in directory
    }
}
else
Console.WriteLine("La directory non esiste");


// ottenere informazioni su una folder

DirectoryInfo infoDirectory = new DirectoryInfo(directory);

Console.WriteLine(infoDirectory.CreationTime);  // creazione della cartella. 
Console.WriteLine(infoDirectory.LastAccessTime); // ultimo accesso.
Console.WriteLine(infoDirectory.LastWriteTime); // ultima modifica.
Console.WriteLine(infoDirectory.Name); // nome della cartella.
Console.WriteLine(infoDirectory.FullName); // percorso completo della cartella.
