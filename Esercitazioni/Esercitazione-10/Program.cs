
/*

ESERCITAZIONE 2

Programma che: 
- genera una password casuale di lunghezza compresa tra i 5 e gli 8 caratteri, che deve contenere almeno una lettera maiuscola, una lettera minuscola,
 un numero e un carattere speciale(es: @,#,!,ecc). Non deve contenere spazi.

*/



Random random             = new Random(); // creo la classe random per la generazione casuale della password

int numeroCaratteri       = random.Next(5,9);
string [] caratteriRandom = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                             "~","!","@","#","$","%", "^","&","*","_","-","+","=","`","|",";","<",">",".","?","/","0","1","2","3","4",
                            "5","6","7","8","9","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", 
                            "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];

List<string> password    = new List<string>();

for(int i = 0; i < numeroCaratteri; i ++)
{
  int carattere             = random.Next(caratteriRandom.Length);
  string generazioneCasuale = caratteriRandom[carattere].Trim();
  password.Add(generazioneCasuale);   
}

// manca il controllo da effettuare sugli intervalli che comprendono minuscole, maiuscole, numeri e caratteri speciali
Console.WriteLine($"La password è:{string.Join("", password)}");

















