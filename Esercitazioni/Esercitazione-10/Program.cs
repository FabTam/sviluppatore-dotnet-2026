
/*

ESERCITAZIONE 2

Programma che: 
- chiede all'utente di inserire il nome di un prodotto, il prezzo e la quantità intervallati da una virgola(esempio "prodotto1,10.5,2") OK
- viene ripulita la stringa di input dagli spazi bianchi OK
- viene verificato che l'input sia valido(deve contenere esattamente 3 parti: nome, prezzo e quantità) OK
- se non è valido viene stampato un messaggio di errore e viene chiesto di inserire nuovamente il prodotto. OK
- ogni prodotto viene aggiunto ad una lista di stringhe con il formato "nome:prodotto1 - prezzo: 10.5 - quantità:2"
- viene chiesto all'utente se vuole inserire un altro prodottox
- se l'utente risponde "y" viene chiesto di inserire un altro prodotto, altrimenti il programma termina x
- la lista dei prodotti viene ordinata in ordine alfabetico e viene stampata a video
*/

List<string> prodotti = new List<string>(); // lista per contenere i prodotti inseriti dall'utente.

while(true)
{
    Console.WriteLine("Inserisci nome del prodotto, il prezzo e la quantità: ");
    string input = Console.ReadLine();
    
    if(string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("input non valido");

    }

    string[] prodottoDiviso = input.Split(",");
    input.Trim();
    if(prodottoDiviso.Length != 3)
    {
        Console.WriteLine("Errore");
        continue;

    }
     
    prodotti.Add($"nome: {prodottoDiviso[0]} - prezzo: {prodottoDiviso[1]} - quantità: {prodottoDiviso[2]}");

    Console.WriteLine("Vuoi inserire un altro prodotto? inserisci? (y/n)");
    string risposta = Console.ReadLine();
    if(risposta != "y")
    {
        break;
    }
    
   
}
prodotti.Sort();
foreach(string p in prodotti)
{
    Console.WriteLine(p);
}







