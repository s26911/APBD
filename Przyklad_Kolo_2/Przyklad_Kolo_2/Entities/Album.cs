namespace Przyklad_Kolo_2.Entities;

public class Album
{
    public int IdAlbum { get; set; }
    public string NazwaAlbumu { get; set; }
    public DateTime DataWydania { get; set; }
    public int IdWytwornia { get; set; }

    public virtual ICollection<Utwor> Utwor { get; set; } = new List<Utwor>();
    public Wytwornia Wytwornia { get; set; }
}