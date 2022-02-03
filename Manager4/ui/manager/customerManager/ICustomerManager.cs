using Manager4.core;
using Manager4.data.model;
using System.Collections.Generic;

namespace Manager4.ui.manager.customerManager
{
    public interface ICustomerManager : INavigation
    {
        void GetAllCustomerSuccess(List<Customer> list);
        void DeleteCustomerSuccess();
        void DeleteCustomerFailure(string message);
    }
}
