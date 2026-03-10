namespace Rubrica.Api.Dtos;

public class ContattoDto
{
    // Dto di risposta: è quello che rimandiamo al frontend
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<string> Competenze { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}