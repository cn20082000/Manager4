using Manager4.core;

namespace Manager4.ui.manager.customerManager.editCustomer
{
    public interface IEditCustomer : INavigation
    {
        void UpdateCustomerSuccess();
        void UpdateCustomerFailure(string message);
    }
}
