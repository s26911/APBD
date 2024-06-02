using APBD_10.RequestModels;

namespace APBD_10.Services;

public interface IPrescriptionService
{
    public void AddPrescription(PrescriptionRequest request);
}