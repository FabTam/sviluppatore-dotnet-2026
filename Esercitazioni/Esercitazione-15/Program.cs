
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;


class Program
{

   static void Main(string[] args)
   {
      ContattiController controller = new ContattiController();

      Menu();


      void Menu()
      {
         while (true)
         {
            Console.WriteLine("Premi 1 per visualizzare la lista dei partecipanti");
            Console.WriteLine("Premi 2 per inserire un partecipante");
            Console.WriteLine("Premi 3 per modificare un partecipante");
            Console.WriteLine("Premi 4 per modificare gli interessi di un partecipante");
            Console.WriteLine("Premi 5 per eliminare gli interessi di un partecipante");
            Console.WriteLine("Premi 6 per eliminare un partecipante");

            Console.WriteLine("Premi 7 per uscire");
            string input = Console.ReadLine();
            // inserire uno switch case

            switch (input)
            {
               case "1":
                  StampaListaPartecipanti();
                  break;

               case "2":
                  InserisciPartecipante();
                  break;

               case "3":
                  ModificaPartecipante();
                  break;

               case "4":
                  ModificaInteressiPartecipante();
                  break;

               case "5":
                  EliminaInteressePartecipante();
                  break;

               case "6":
                  EliminaPartecipante();
                  break;

               case "7":
                  return;

               default:
                  Console.WriteLine("Scelta non valida!");
                  break;

            }
         }


      }

      string LeggiInput(string messaggio)
      {
         Console.WriteLine(messaggio);
         string input = Console.ReadLine();

         return input;
      }


      void StampaListaPartecipanti()
      {
         Console.WriteLine("Tabella partecipanti");
         Console.WriteLine(new string('-', 60));
         Console.WriteLine($"{"ID",-4} {"NOME",-10} {"ETA",-5} {"PRESENTE",-10} {"INTERESSI",-20}");
         foreach (var p in controller.GetContatti())
         {
            Console.WriteLine($"{p.Id,-4}  {p.Nome,-8}  {p.Eta,-5} {p.Presente,-10}  {string.Join(", ", p.Interessi)}");
         }


      }

      void InserisciPartecipante()
      {

         Console.Write("Nome:");
         string nome = Console.ReadLine();
         Console.Write("Età: ");
         string eta = Console.ReadLine();
         Console.Write("Presente(true/false)");
         bool presente = bool.Parse(Console.ReadLine());
         Console.Write("Inserisci gli interessi, se più di uno separali con una virgola:");
         string interesse = Console.ReadLine();
         List<string> interessi = interesse.Split(",").ToList();

         controller.AggiungiContatto(nome, eta, presente, interessi);

      }

      Contatto ScegliPartecipante()
      {
         int scelta = int.Parse(LeggiInput("Inserisci l'id del partecipante:"));

         foreach (var p in controller.GetContatti())
         {
            if (p.Id == scelta)
            {
               Console.WriteLine($"Hai scelto l'id {p.Id}");
               return p;
            }
         }

         Console.WriteLine("Partecipante non trovato");
         return null;
      }



      void ModificaPartecipante()
      {
         // Stampo la lista dei partecipanti
         StampaListaPartecipanti();
         int id = int.Parse(LeggiInput("Inserisci l'id del partecipante da modificare:"));
         string nome = LeggiInput("Modifica il nome: ");
         string eta = LeggiInput("Modifica l'età:");
         bool presente = bool.Parse(LeggiInput("Modifica la presenza:"));
         string interesse = LeggiInput("Modifica gli interessi:");
         string inputInteressi = LeggiInput("Interessi separati da virgola:");
         List<string> interessi = inputInteressi.Split(",").ToList();


         controller.ModificaContatto(id, nome, eta, presente, interessi);




      }


      void EliminaPartecipante()
      {
         StampaListaPartecipanti();
         int id = int.Parse(LeggiInput("Inserisci l'id del partecipante da eliminare:"));
         controller.VisualizzaContatto(id);
         controller.EliminaContatto(id);


      }

      void ModificaInteressiPartecipante()
      {
         StampaListaPartecipanti();

         var partecipante = ScegliPartecipante();
         if (partecipante == null)
            return;

         partecipante.Interessi = LeggiInput("Inserisci gli interessi separati da virgola:").Split(",").ToList();

      }


      void EliminaInteressePartecipante()
      {
         StampaListaPartecipanti();
         var partecipante = ScegliPartecipante();

         if (partecipante == null)
            return;

         for (int j = 0; j < partecipante.Interessi.Count; j++)
         {
            Console.WriteLine($"{j} - {partecipante.Interessi[j]}");
         }

         int scelta = int.Parse(LeggiInput("Scegli quale interesse eliminare"));

         if (scelta < 0 || scelta >= partecipante.Interessi.Count)
         {
            Console.WriteLine("Indice non valido");
            return;
         }

         partecipante.Interessi.RemoveAt(scelta);


      }
   }

}







