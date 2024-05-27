namespace APBD_10.Entities;

public class Student
{
    public int id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IndexNumber { get; set; }
    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}