
/*

ESERCITAZIONE 4

Programma che: 

Legge un elenco di frasi da una lista, per ognuna genera uno slug(versione adattata ad essere usata in un URL)
e le stampa. Lo slug generato deve essere così:

- deve essere tutto in minuscolo.
- deve sostituire gli spazi con trattini.
- deve rimuovere la punteggiatura.
- deve rimuovere eventuali trattini doppi.

*/

using System.Xml;

List<string> frasi = new List<string>()
{
    "buongiorno, mi chiamo Fabio", "sono nato a Napoli.", "la mia mail è fabiotamma!--90@gmail.com"
};

List<char> punteggiatura = new List<char>()
{
    '!','?','.',',','.'

};

foreach (var frase in frasi)
{
    string slug = frase.ToLower();

    foreach (char c in punteggiatura)
    {
        slug = slug.Replace(c.ToString(), "");
    }

    slug = slug.Replace(" ", "-");

    while (slug.Contains("--"))
    {
        slug = slug.Replace("--", "-");
    }

    Console.WriteLine(slug);
}




















