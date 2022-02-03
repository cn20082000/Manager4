using Manager4.core;
using Manager4.data.model;
using System.Collections.Generic;

namespace Manager4.ui.manager.customerManager.viewCustomer
{
    public interface IViewCustomer : INavigation
    {
        void GetPrescriptionSuccess(List<Prescription> list);
    }
}
