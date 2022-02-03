using Manager4.core;
using Manager4.data.model;

namespace Manager4.ui.prescription
{
    public interface INewPrescription : INavigation
    {
        void GetLastPrescriptionSuccess(Prescription oldPrescription);
        void GetLastPrescriptionFailure(string message);
        void CreatePrescriptionSuccess(Prescription prescription);
        void CreatePrescriptionFailure(string message);
    }
}
