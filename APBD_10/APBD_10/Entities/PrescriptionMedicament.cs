namespace APBD_10.Entities;

public class PrescriptionMedicament
{
    public int Dose { get; set; }
    public string Details { get; set; }
    public Medicament Medicament { get; set; }
    public Prescription Prescription { get; set; }
}