//LOGICA CONDIZIONALE

int eta = 20;

if(eta >= 18)
{
    Console.WriteLine("La persona è maggiorenne"); // Verifico l'età, SE maggiore o uguale a 18 stampo l'argomento del Writeline.
}

int etaPersona = 17;
if(etaPersona >= 18)
{
    Console.WriteLine("La persona è maggiorenne");
}
else
{
    Console.WriteLine("La persona è minorenne"); // l'else valuta la condizione false dell'if.
}

int punteggio = 75;

if( punteggio >= 90)
{
    Console.WriteLine("Voto: A");
}
else if( punteggio >= 80)
{
    Console.WriteLine("Voto: B");
}
else if(punteggio >= 70)
{
    Console.WriteLine("Voto: C");
}
else if(punteggio >= 60)
{
    Console.WriteLine("Voto: D");    
}
else
{
    Console.WriteLine("Voto:F");
}

// FIZZ BUZZ

Console.WriteLine("Digita un numero:");
int numero = int.Parse(Console.ReadLine());

if ( (numero % 3 == 0) && (numero % 5 == 0) )
{
    Console.WriteLine("FizzBuzz");
}
else if(numero % 3 == 0)
{
    Console.WriteLine("Fizz");
}
else if ( numero % 5 == 0)
{
    Console.WriteLine("Buzz");
}
else
{
    Console.WriteLine($"Il numero è: {numero}");
}