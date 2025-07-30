namespace Boekenbeheer.WebAPI.Dto;

public class BoekDto
{
  public Guid Id { get; set; }
  public string Titel { get; set; } = string.Empty;
  public string Auteur { get; set; } = string.Empty;
  public string ISBN { get; set; } = string.Empty;
  public int AantalPaginas { get; set; }
  public DateTime PublicatieDatum { get; set; }
  public bool IsUitgeleend { get; set; }
}