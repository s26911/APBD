namespace APBD_10.Entities;

public class Group
{
    public int id { get; set; }
    public string name { get; set; }
    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}