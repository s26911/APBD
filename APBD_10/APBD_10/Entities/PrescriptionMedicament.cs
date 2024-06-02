namespace APBD_10.Entities;

public class PrescriptionMedicament
{
    public int Dose { get; set; }
    public string Details { get; set; }
    public int MedicamentId { get; set; }
    public int PrescriptionId { get; set; }
    public virtual Medicament Medicament { get; set; }
    public virtual Prescription Prescription { get; set; }
}