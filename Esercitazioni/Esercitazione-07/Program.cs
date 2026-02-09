// FIZZBUZZ CON CICLO FOR


using System.ComponentModel;
using System.Xml.Schema;

int indice = 1;
for(indice = 1; indice <= 100; indice ++)
{
    if(indice % 3 == 0 && indice % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if(indice % 3 == 0)
    {
        Console.WriteLine("Fizz");

    }
    else if(indice % 5 == 0)
    {
        Console.WriteLine("Buzz");

    }
    else
    {
        Console.WriteLine($"Il numero è : {indice}");
    }
}

// FIZZBUZZ CON IL CICLO FOR EACH

List<int> listaNumeri = new List<int>{355, 421, 485810, 5931, 5710, 4, 18, 581, 304};

foreach(var numero in listaNumeri)
{
     if(numero % 3 == 0 && numero % 5 == 0)
    {
        Console.WriteLine($"{numero} FizzBuzz");
    }
    else if(numero % 3 == 0)
    {
        Console.WriteLine($"{numero} Fizz");

    }
    else if(numero % 5 == 0)
    {
        Console.WriteLine($"{numero} Buzz");

    }
    else
    {
        Console.WriteLine($"Il numero è : {numero}");
    }
}

// ESERCITAZIONE PARSE E CASTING CON CICLO FOR

int index = 1;
for( index = 1; index <= 5; index ++)
{
    Console.Write("Inserisci un numero:");
    int input = int.Parse(Console.ReadLine());
    Console.WriteLine($"Il nome inserito è: {input}");

}

// ESERCITAZIONE CON CICLO FOREACH

List<int> numeri = new List<int>();
Console.Write("Inserisci un numero:");
int inserimento = int.Parse(Console.ReadLine());
numeri.Add(inserimento);
while (inserimento != 0)
{
    Console.Write("Inserisci un numero: ");
    inserimento = int.Parse(Console.ReadLine());
    numeri.Add(inserimento);
}
foreach(var numero in numeri)
{
    Console.Write($"{numero},");
}





