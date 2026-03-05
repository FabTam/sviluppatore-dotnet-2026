public class lastIdController
{
   // private non dà accessibilità ad altre parti del programma
   // readonly per indicare che il valore non può essere modificato dopo l'inizializzazione
   private readonly string origin;
   private readonly string path;
   private LastId lastIdObj;

   // indico il costruttore della classe

   public lastIdController()
   {
      origin    = "Data";
      path      = Path.Combine(origin, "lastId.json");
      lastIdObj = JsonHelper.Leggi<LastId>(path) ?? new LastId { Id = 0 };

   }

   public int GetNextId()
   {
      lastIdObj.Id++;
      Salva();
      return lastIdObj.Id;

   }

   private void Salva()
   {
      JsonHelper.Salva(path, lastIdObj);
   }
}