// See https://aka.ms/new-console-template for more information
// Questo è un commento in C# a linea singola

/*
  Questo è un commento in C#
  a più linee
*/

Console.WriteLine("Hello, World!");
// Console è una classe predefinita in C# che mette a disposizione diversi metodi
// Writeline è un metodo della classe Console che stampa una stringa sulla console
// Generalmente ogni metodo ha le parentesi all'interno delle quali si specificano i parametri o gli argomenti

Console.Write("Inserisci il tuo nome:");// Write è un metodo della classe Console che stampa una stringa sulla console senza andare a capo

 // Console.ReadLine(); ReadLine è un metodo della classe Console che legge una riga di input dalla console

string nome = Console.ReadLine();

Console.Write("Inserisci il tuo cognome:");

string cognome = Console.ReadLine();
// acquisire l'input dell'utente e memorizzarlo un una variabile
// leggo il nome da tastiera e lo assegno alla variabile nome
// stampo il nome acquisito

 // Console.WriteLine("Ciao, " + nome +"!"); Concatenazione di stringhe

Console.WriteLine($"Ciao, {nome} {cognome}!"); // Interpolazione (metodo da usare)


