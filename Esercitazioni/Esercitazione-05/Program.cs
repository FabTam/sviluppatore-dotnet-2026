// SWITCH (CONDIZIONALI) ALTERNATIVO A IF ELSE, MA PIù COMODO SUI SINGOLI VALORI

Console.Write("Scegli una opzione fra 1, 2 o 3");
int scelta = int.Parse(Console.ReadLine());

switch(scelta)
{
    case 1:
       Console.WriteLine("Hai scelto l'opzione 1.");
       break;
    case 2:
       Console.WriteLine("Hai scelto l'opzione 1.");
       break;
    case 3:
       Console.WriteLine("Hai scelto l'opzione 1.");
       break;
    default:
       Console.WriteLine("Scelta non valida");
    break;
}

