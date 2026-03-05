using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;


public class ContattiController
{
   // queste sono le variabili di istanza della classe ContattiController, cioè le variabili che appartengono a ogni istanza
   private readonly string origin;
   private readonly string path;

   private List<Contatto> contatti;
   private lastIdController lastIdController;

   public ContattiController()
   {
      origin           = "Data";
      path             = Path.Combine(origin, "listapartecipanti.json");
      lastIdController = new lastIdController();
      contatti         = JsonHelper.Leggi<List<Contatto>>(path) ?? new List<Contatto>();
      Console.WriteLine(path);
      Console.WriteLine(File.Exists(path));
    
   }

   public List<Contatto> GetContatti()
   {
      return contatti;
   }


   public void AggiungiContatto(string nome, string eta, bool presente, List<string> interessi)
   {
      Contatto nuovoContatto = new Contatto
      {
         Id = lastIdController.GetNextId(),
         Nome = nome,
         Eta = eta,
         Presente = presente,
         Interessi = interessi
      };

      var context = new ValidationContext(nuovoContatto);

      try
      {
         Validator.ValidateObject(nuovoContatto, context, true);
      }
      catch (ValidationException ex)
      {
         Console.WriteLine($"Errore: {ex.Message}");
         return;
      }
      contatti.Add(nuovoContatto);
      Salva();
   }

   private void Salva()
   {
      JsonHelper.Salva(path, contatti);
   }

   public void ModificaContatto(int id, string nome, string eta, bool presente, List<string> interessi)
   {
      Contatto contattoEsistente = null;
      foreach (var c in contatti)
      {
         if (c.Id == id)
         {
            contattoEsistente = c;
            break;
         }
      }
      if (contattoEsistente != null)
      {
         contattoEsistente.Nome = nome;
         contattoEsistente.Eta = eta;
         contattoEsistente.Presente = presente;
         contattoEsistente.Interessi = interessi;

         var context = new ValidationContext(contattoEsistente);
         try
         {
            Validator.ValidateObject(contattoEsistente, context, true);
         }
         catch (ValidationException ex)
         {
            Console.WriteLine($"Errore: {ex.Message}");
            return;
         }
         Salva();
      }
   }

   public void ModificaInteresse(int id, List<string> interessi)
   {
      Contatto contattoEsistente = null;
      foreach (var c in contatti)
      {
         if (c.Id == id)
         {
            contattoEsistente = c;
            break;
         }
      }

      if (contattoEsistente != null)
      {
         contattoEsistente.Interessi = interessi;
      }
      Salva();
   }

   public void EliminaInteresse(int id, int scelta)
   {
      Contatto contattoEsistente = null;
      foreach (var c in contatti)
      {
         if (c.Id == id)
         {
            contattoEsistente = c;
            break;
         }
      }

      if (contattoEsistente != null)
      {
         contattoEsistente.Interessi.RemoveAt(scelta);
      }
      Salva();

   }

   public void EliminaContatto(int id)
   {
      Contatto contattoEsistente = null;
      foreach (var c in contatti)
      {
         if (c.Id == id)
         {
            contattoEsistente = c;
            break;
         }
      }
      if (contattoEsistente != null)
      {
         contatti.Remove(contattoEsistente);
         Salva();


      }
   }

   public Contatto VisualizzaContatto(int id) // uso ? per indicare che il metodo può restituire un oggetto Confatto o null
   {
      Contatto? contattoEsistente = null;
      foreach (var c in contatti)
      {
         if (c.Id == id)
         {
            contattoEsistente = c;
            break;
         }

      }
      if (contattoEsistente == null)
      {
         throw new Exception($"Contatto con ID {id} non trovato");
      }
      return contattoEsistente;
   }


}