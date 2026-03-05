/*
Scrivi un programma che:

controlla se esiste il file prova.txt

se non esiste, lo crea

stampa un messaggio a schermo

Metodi utili:

File.Exists()
File.Create()


Scrivi un programma che:

legge il contenuto di prova.txt

lo stampa nella console

Metodo utile:

File.ReadAllText()


Scrivi un programma che:

chiede all’utente una frase

la aggiunge alla fine del file log.txt


Dato un file testo.txt, scrivi un programma che:

legge tutte le righe

stampa quante righe contiene

Metodo utile:


Scrivi un programma che:

copia prova.txt

in backup_prova.txt
*/

string originPath = ".";


string pathCartellaData = Path.Combine(originPath, "Data");
if (!Directory.Exists(pathCartellaData))
{
    Directory.CreateDirectory(pathCartellaData);
}
else
    Console.WriteLine("La cartella è già presente");

string[] filesInData = Directory.GetFiles(pathCartellaData);

foreach (string f in filesInData)
{
    string nomeFile = Path.GetFileName(f);
    string estensioneFile = Path.GetExtension(f);

    Console.WriteLine($"Questi sono i files presenti: {f}");
    Console.WriteLine($"Questi sono i nomi dei files presenti: {nomeFile}");
    Console.WriteLine($"Questi sono i nomi dei files presenti: {estensioneFile}");
}
