using Manager4.core;
using Manager4.data.model;
using System.Collections.Generic;

namespace Manager4.ui.search.searchCustomer
{
    public interface ISearchCustomer : INavigation
    {
        void FindCustomerSuccess(List<Customer> list);
    }
}
