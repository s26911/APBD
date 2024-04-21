namespace APBD_05.Models;

public class Animal
{
    public enum Categories
    {
        Kot, Pies, Chomik, Szczur
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public Categories Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
}