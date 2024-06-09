namespace Przyklad_Kolo_2.Entities;

public class WykonawcaUtworu
{
    public int IdMuzyk { get; set; }
    public int IdUtwor { get; set; }

    public Muzyk Muzyk { get; set; }
    public Utwor Utwor { get; set; }
}