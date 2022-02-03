using Manager4.core;
using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.obj;
using System;

namespace Manager4.ui.manager.customerManager
{
    public class CustomerManagerViewModel : BaseViewModel<ICustomerManager>
    {
        public void GetAllCustomer(int page, int pageSize, CustomerAttrEnum sortBy, bool isAsc)
        {
            dataManager.GetAllCustomer(new Pageable<CustomerAttrEnum>(page, pageSize, sortBy, isAsc))
                .WhenSuccess(data => Navigation.GetAllCustomerSuccess(data))
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }

        public void DeleteCustomer(Customer customer)
        {
            dataManager.DeleteCustomer(customer)
                .WhenSuccess(data => Navigation.DeleteCustomerSuccess())
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.DeleteCustomerFailure(Resource("delete_customer_fail") as string);
                })
                .Call();
        }
    }
}
