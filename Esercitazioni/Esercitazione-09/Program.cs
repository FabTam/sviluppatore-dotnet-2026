// METODI ARRAY

/* Gli array hanno delle caratteristiche che li rendono molto utili, ma i metodi sono abbastanza limitati rispetto ad altre collezione come le List. 
Questo è dovuto al fatto che è una struttura dati più semplice e più performante ma meno flessibile.
*/

/* LENGTH
 Il metodo Length resituisce la lunghezza dell'array, ovvero il numero di elementi che contiene. Importante notare che la lunghezza di un array è fissa
 e non può essere modificata dopo la sua creazione.
*/

int[] numeri = {1,2,3,4,5};
Console.WriteLine(numeri.Length); // output: 5

/* COPY
 Il metodo Copy permette di copiare gli elementi di un array in un altro array.
 Necessario specificare l'array di origine, l'array di destinazione e il numero di elementi da copiare.
*/

int[] numeriCopia = new int[numeri.Length]; // dichiaro l'array
Array.Copy(numeri, numeriCopia, numeri.Length);
Console.WriteLine(string.Join(",", numeriCopia)); // output : 1,2,3,4,5

/* CLEAR
 Il metodo Clear permette di resettare i valori degli elementi di un array, specificando l'indice di partenza e il numero di elementi da resettare.
 Nel caso di array di interi i valori vengono resettati a zero. 
 Nel caso di array di stringhe i valori vengono resettati a null.
*/

Array.Clear(numeriCopia, 0, numeriCopia.Length); // resetta dall'indice fino alla lunghezza dell'array
Console.WriteLine(string.Join(",", numeriCopia)); // ouput: 0,0,0,0

/* REVERSE
 Inverte l'ordine degli elementi.
*/

Array.Reverse(numeri); // reverse inverte l'array.
Console.WriteLine(string.Join(",", numeri)); // output: 5,4,3,2,1

/*
SORT
 Il metodo Sort permette di ordinare gli elementi di un array in ordine crescente.
 Per ordinare in modo decrescente inverto con reverse e uso sort.
*/

Array.Sort(numeri);
Console.WriteLine(string.Join(",", numeri)); // Ouput 1,2,3,4,5

/* INDEX OF
 Restituisce l'indice di un elemento di un array e se non viene trovato restituisce -1.
 Se ci sono più occorrenze restituisce l'indice del primo elemento trovato.
*/

int indice = Array.IndexOf(numeri,3);
Console.WriteLine(indice); // output: 2

/*
 ESERCITAZIONE DADO DA GIOCO V5
 - genera un array di 5 elementi interi inizializzati a zero
 - chiede all'utente di lanciare un dado(premendo 1 come prima)
 - chiede ad ogni lancio di tenere il risultato con 1 e 0 per scartare
 - lancia fino alla capacità dell'array .
 - ordina i lanci in modo decrescente
 - copia i lanci con valore maggiore = a 5 in un nuovo array e stampa il nuovo array

 */

Random random = new Random();


int[] array = new int[5];
int[] arrayLanci = new int[array.Length];
Console.WriteLine("Lancia il dado premendo 1:");
string input = Console.ReadLine();
for(int i = 0; i < array.Length; i++)
{
    if( input == "1")
    {
    int dado = random.Next(1, 7);
    Console.WriteLine($"Lancio: {dado}");
    Console.WriteLine("Vuoi tenere il lancio? Digita 1 per tenere o 0 per confermare");
    string scelta = Console.ReadLine();
    if( scelta == "1")
    {
        array[i] = dado;
    }
    else if( scelta == "0")
        {
            Console.WriteLine("Lancio scartato");
            i--;
        }
    else
        {
            Console.WriteLine("Comando non permesso");
            i--;
        }
    }
}

Array.Sort(array);
Array.Reverse(array);
Console.WriteLine(string.Join("," , array ));

int j = 0;
for(int i = 0; i < array.Length; i++)
{
    
    if(array[i] >= 5)
    {
        arrayLanci[j] = array[i];
        j++;
    }
}
Console.WriteLine(string.Join("," , arrayLanci ));


