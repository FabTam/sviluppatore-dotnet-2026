using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


public static class Validatore
{
    public static void ValidaOggetto(object obj)
    {
        var context = new ValidationContext(obj);
        try
        {
            Validator.ValidateObject(obj, context, true);
        }

        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


}