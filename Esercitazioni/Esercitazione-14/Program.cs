
/*
 USING e accesso ai files in uso.

*/
string percorso = @"test.txt";
if (File.Exists(percorso))
{
    using (StreamReader lettore = new StreamReader(percorso))
    {
        string content = lettore.ReadToEnd();

    }
}
else
    Console.WriteLine("il file non esiste");
/*

 Se un file è in uso da un altro processo, tenetare di accedervi puà generare una eccezione. E importante gestire queste eccezionie per evitare che l'applicazione si blocchi.
 Ecco un esempio di come gestire l'eccezione IOException quando si tenta di accedere a un file in uso:
*/

string path = @"test.txt";
try
{
    using (StreamReader reader = new StreamReader(path))
    {
        string content = reader.ReadToEnd();
        Console.WriteLine(content);
    }


}
catch (IOException ex)
{
    Console.WriteLine($"il file è in uso da un altro processo. Dettagli: {ex.Message} ");
}


