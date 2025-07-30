namespace Boekenbeheer.WebAPI.Dto;

public class CreateBoekDto
{
  public string Titel { get; set; } = string.Empty;
  public string Auteur { get; set; } = string.Empty;
  public string ISBN { get; set; } = string.Empty;
  public int AantalPaginas { get; set; }
  public DateTime PublicatieDatum { get; set; }
}
