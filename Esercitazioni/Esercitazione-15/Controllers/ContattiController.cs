public class ContattiController
{
   // queste sono le variabili di istanza della classe ContattiController, cioè le variabili che appartengono a ogni istanza
   private readonly string path = "listapartecipanti.json";
   private List<Contatto> contatti;
   private lastIdController lastIdController;

   public ContattiController()
   {
      lastIdController = new lastIdController();
      contatti = JsonHelper.Leggi<List<Contatto>>(path) ?? new List<Contatto>();
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
         Salva();
      }
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