
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Tracing;
using System.Net;
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
         Console.Write(messaggio);
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

         string nome = LeggiInput("Nome:");
         string eta  = LeggiInput("Età:");
         bool presente;
         while (true)
         {

            string input = LeggiInput("Presente: inserisci si oppure no:");
            if (input == "si")
            {
               presente = true;
               break;
            }
            else if (input == "no")
            {
               presente = false;
               break;
            }
            else
               Console.WriteLine("Inserisci solo si o no.");
         }
         string interesse = LeggiInput("Inserisci gli interessi, se più di uno separali con una virgola:");
         List<string> interessi = interesse.Split(",").ToList();

         controller.AggiungiContatto(nome, eta, presente, interessi);

      }

      /* Contatto ScegliPartecipante()
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
        */


      void ModificaPartecipante()
      {
         // Stampo la lista dei partecipanti
         StampaListaPartecipanti();

         int id = int.Parse(LeggiInput("Inserisci l'id del partecipante da modificare:"));
         Contatto contatto = controller.VisualizzaContatto(id);
         string nome = LeggiInput("Modifica il nome: ");
         string eta = LeggiInput("Modifica l'età:");
         bool presente = contatto.Presente;
         if (!string.IsNullOrWhiteSpace(nome))
            contatto.Nome = nome;
         if (!string.IsNullOrWhiteSpace(eta))
            contatto.Eta = eta;
         while (true)
         {

            string input = LeggiInput("Presente: inserisci si oppure no:");
             if (string.IsNullOrWhiteSpace(input))
                break;
            if (input == "si")
            {
               presente = true;
               break;
            }
            else if (input == "no")
            {
               presente = false;
               break;
            }
            else
               Console.WriteLine("Inserisci solo si o no.");
         }
         string inputInteressi = LeggiInput("Inserisci gli interessi separati da virgola:");
         List<string> interessi;
         if (!string.IsNullOrWhiteSpace(inputInteressi))
         {
            interessi = inputInteressi.Split(",").ToList();

            contatto.Interessi = interessi;
         }



         controller.ModificaContatto(contatto.Id, nome, eta, presente, contatto.Interessi);

      }


      void EliminaPartecipante()
      {
         StampaListaPartecipanti();
         int id = int.Parse(LeggiInput("Inserisci l'id del partecipante da eliminare:"));
         controller.VisualizzaContatto(id);
         Contatto contatto = controller.VisualizzaContatto(id);
         controller.EliminaContatto(contatto.Id);


      }

      void ModificaInteressiPartecipante()
      {
         StampaListaPartecipanti();

         int id = int.Parse(LeggiInput("Inserisci l'id del partecipante da modificare:"));
         Contatto contatto = controller.VisualizzaContatto(id);
         string inputInteressi = LeggiInput("Inserisci gli interessi separati da virgola:");
         if (!string.IsNullOrWhiteSpace(inputInteressi))
         {
            List<string> interessi = inputInteressi.Split(",").ToList();

            contatto.Interessi = interessi;
         }

         controller.ModificaInteresse(contatto.Id, contatto.Interessi);

      }


      void EliminaInteressePartecipante()
      {
         StampaListaPartecipanti();
         int id = int.Parse(LeggiInput("Inserisci l'id del partecipante da eliminare:"));
         controller.VisualizzaContatto(id);
         List<Contatto> listaContatti = controller.GetContatti();

         for (int i = 0; i < listaContatti[id - 1].Interessi.Count; i++)
         {
            Console.WriteLine($"{i} - {listaContatti[id - 1].Interessi[i]}");
         }

         int scelta = int.Parse(LeggiInput("Scegli quale interesse eliminare"));

         if (scelta < 0 || scelta >= listaContatti[id - 1].Interessi.Count)
         {
            Console.WriteLine("Indice non valido");
            return;
         }

         controller.EliminaInteresse(id, scelta);


      }
   }

}







