using Manager4.core;
using Manager4.data.model;

namespace Manager4.ui.manager.customerManager.addCustomer
{
    public interface IAddCustomer : INavigation
    {
        void AddCustomerSuccess(Customer customer);
        void AddCustomerFailure(string message);
    }
}
