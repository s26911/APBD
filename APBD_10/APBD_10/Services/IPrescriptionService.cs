using APBD_10.RequestModels;

namespace APBD_10.Services;

public interface IPrescriptionService
{
    public bool AddPrescription(PrescriptionRequest request);
}