using Manager4.core;
using Manager4.data.model;
using System;

namespace Manager4.ui.manager.customerManager.viewCustomer
{
    public class ViewCustomerViewModel : BaseViewModel<IViewCustomer>
    {
        public void GetPrescription(Customer customer)
        {
            dataManager.GetAllPrescription(customer)
                .WhenSuccess(data => Navigation.GetPrescriptionSuccess(data))
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }
    }
}
