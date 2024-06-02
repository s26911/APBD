using APBD_10.Entities;

namespace APBD_10.RequestModels;

public class PrescriptionRequest
{
    public PatientRequest Patient { get; set; }
    public List<MedicamentRequest> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}