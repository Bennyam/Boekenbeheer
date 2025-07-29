namespace Boekenbeheer.Domain.Entities;

public class Boek
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Titel { get; private set; }
    public string Auteur { get; private set; }
    public string ISBN { get; private set; }
    public int AantalPaginas { get; private set; }
    public DateTime PublicatieDatum { get; private set; }
    public bool IsUitgeleend { get; private set; } = false;

    public Boek(string titel, string auteur, string isbn, int aantalPaginas, DateTime publicatieDatum)
    {
        if (string.IsNullOrWhiteSpace(titel))
            throw new ArgumentException("Titel mag niet leeg zijn.", nameof(titel));
        if (string.IsNullOrWhiteSpace(auteur))
            throw new ArgumentException("Auteur mag niet leeg zijn.", nameof(auteur));
        if (string.IsNullOrWhiteSpace(isbn))
            throw new ArgumentException("ISBN mag niet leeg zijn.", nameof(isbn));
        if (aantalPaginas <= 0)
            throw new ArgumentException("Aantal pagina's moet groter dan 0 zijn.");

        Titel = titel;
        Auteur = auteur;
        ISBN = isbn;
        AantalPaginas = aantalPaginas;
        PublicatieDatum = publicatieDatum;
    }

    public void MarkeerAlsUitgeleend()
    {
        if (IsUitgeleend)
            throw new InvalidOperationException("Dit boek is al uitgeleend.");
        IsUitgeleend = true;
    }

    public void MarkeerAlsBeschikbaar()
    {
        if (!IsUitgeleend)
            throw new InvalidOperationException("Dit boek is al beschikbaar.");
        IsUitgeleend = false;
    }
}
