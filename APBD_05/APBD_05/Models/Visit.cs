namespace APBD_05.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public double price { get; set; }
}