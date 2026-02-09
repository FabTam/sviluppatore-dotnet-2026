// CICLI

for(int i = 1; i <= 10; i ++) // Ciclo for{inizializzazione, condizione, incremento}
{
    Console.WriteLine(i);
}


int[] numeri = [];
foreach( var numero in numeri)
{
    // blocco di codice da eseguire (Ciclo foreach{ var elemento in collezione})
}

List<string> nomi = new List<string>{"Nome1", "Nome2","Nome3"};

foreach(var nome in nomi)
{
    Console.WriteLine(nome);
}

Dictionary<int,string> dizionario = new Dictionary<int, string>
{
    {1, "Uno"},
    {2, "Due"},
    {3, "Tre"}

};

foreach(var kvp in dizionario)
{
    Console.WriteLine($"Chiave: {kvp.Key}, Valore: {kvp.Value}"); // kvp è una variabile che rappresenta ogni coppia chiave-valore del dizionario.
}

int j = 1;
while(j <= 10)
{
    Console.WriteLine(j); // While(condizione) cicla fintanto che la condizione sia vera.
    j++;
}

int indice = 1;
do
{
    Console.WriteLine(indice);// Esegue il ciclo almeno una volta, poi verifica la condizione.
}
while(indice <= 10);