/* ESERCITAZIONE 4
 Programma Calcolatrice basato sulle funzioni:

    Il programma deve:
    
    - L'utente deve inserire una operazione da calcolare
    - il programma calcolerà l'operazione in base all'input se l'operazione è possibile
    - l'input deve avere queste limitazioni:
    . deve essere una stringa di input unica che contiene l'operazione da calcolare. 
    . deve avere 2 numeri e solo 1 operatore +,-,*,/

    */










Calcola();

void Calcola()
{
    while (true)
    {
        Console.WriteLine("Inserisci una operazione da calcolare o premi 0 per spegnere:");
        string input = Console.ReadLine();

        if (input == "0")
            break;

        char[] operatori = { '+', '-', '*', '/' };
        char operatore = '\0';

        foreach (char o in operatori)
        {
            if (input.Contains(o))
            {
                operatore = o;
                break;
            }
        }

        if (operatore == '\0')
        {
            Console.WriteLine("Operatore non valido!");
            continue;
        }

        string[] numeri = input.Split(operatore);

        if (numeri.Length != 2)
        {
            Console.WriteLine("Formato non valido!");
            continue;
        }

        if (!int.TryParse(numeri[0], out int operando1) ||
            !int.TryParse(numeri[1], out int operando2))
        {
            Console.WriteLine("Inserisci solo numeri validi!");
            continue;
        }

        switch (operatore)
        {
            case '+':
                Stampa(Somma(operando1, operando2));
                break;

            case '-':
                Stampa(Sottrazione(operando1, operando2));
                break;

            case '*':
                Stampa(Moltiplicazione(operando1, operando2));
                break;

            case '/':
                if (operando2 == 0)
                {
                    Console.WriteLine("Impossibile dividere per zero!");
                }
                else
                {
                    Stampa(Divisione(operando1, operando2));
                }
                break;
        }
    }
}


int Somma(int numero1, int numero2)
{
    int result = numero1 + numero2;
    return result;

}

int Sottrazione(int numero1, int numero2)
{
    int result = numero1 - numero2;
    return result;
}

int Divisione(int numero1, int numero2)
{
    if (numero2 == 0)
    {
        Console.WriteLine("Impossibile dividere per zero");
    }

    int result = numero1 / numero2;
    return result;
}

int Moltiplicazione(int numero1, int numero2)
{
    int result = numero1 * numero2;
    return result;
}


void Stampa(int risultato)
{
    Console.WriteLine($"Questo è il risultato: {risultato}");
}