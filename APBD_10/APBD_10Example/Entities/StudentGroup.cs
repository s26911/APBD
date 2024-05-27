using System.Text.RegularExpressions;

namespace APBD_10.Entities;

public class StudentGroup
{
    public int idGroup { get; set; }
    public int idStudent { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual System.Text.RegularExpressions.Group Group { get; set; } // tam gdzie fk tam pojawia się referancja do klasy nadrzędnej
    public virtual Student Student { get; set; }
}