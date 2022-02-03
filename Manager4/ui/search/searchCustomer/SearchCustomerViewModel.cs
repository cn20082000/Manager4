using Manager4.core;
using Manager4.util.enu;

namespace Manager4.ui.search.searchCustomer
{
    public class SearchCustomerViewModel : BaseViewModel<ISearchCustomer>
    {
        public void FindCustomer(SearchEnum type, string key)
        {
            if (type == SearchEnum.NAME_CUSTOMER)
            {
                dataManager.FindCustomerByName(key)
                    .WhenSuccess(data => Navigation.FindCustomerSuccess(data))
                    .Call();
            }
            else if (type == SearchEnum.PHONE_NUMBER_CUSTOMER)
            {
                dataManager.FindCustomerByPhoneNumber(key)
                    .WhenSuccess(data => Navigation.FindCustomerSuccess(data))
                    .Call();
            }
        }
    }
}
