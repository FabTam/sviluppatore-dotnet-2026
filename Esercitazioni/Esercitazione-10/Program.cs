
/*

ESERCITAZIONE 3

Programma che: 

Legge un elenco di email da una lista, per ognuna maschera la parte dell'utente(prima della @) lasciando visibile solo la prima lettera e l'ultima lettera
mantenendo visibile il dominio (es: "j***i@example.com) e la stampa.
Il numero degli asterischi deve essere uguale al numero di caratteri mascherati.

*/

using System.ComponentModel.DataAnnotations;

List<string> email = new List<string>()
{
    "fabiotamma90@gmail.com","the_shining_surfer@hotmail.it","godrick_griffyndor@yahoo.it",

};

foreach(var e in email)
{
  string maschera                 = "";
  int indiceChiocciola            = e.IndexOf("@"); // trovo l'indice della chiocciola
  string sottostringaDaMascherare = e.Substring(1, indiceChiocciola -2); // estraggo la sottostringa da mascherare mettendo 1 e l'indice della chiocciola -1
  
  for(int i = 0; i < sottostringaDaMascherare.Length; i++)
    {
        maschera += "*";
    }
    string emailMascherata = e.Replace(sottostringaDaMascherare,maschera);
    
   Console.WriteLine(emailMascherata);
}

















