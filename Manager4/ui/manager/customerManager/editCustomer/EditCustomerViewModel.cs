using Manager4.core;
using Manager4.data.model;
using Manager4.util.value;
using System;

namespace Manager4.ui.manager.customerManager.editCustomer
{
    public class EditCustomerViewModel : BaseViewModel<IEditCustomer>
    {
        public void UpdateCustomer(Customer customer, string name, DateTime? birthday, string address, string phoneNumber)
        {
            if (!Reg.Name.IsMatch(name))
            {
                Navigation.UpdateCustomerFailure(Resource("name_fail") as string);
                return;
            }
            if (birthday == null)
            {
                Navigation.UpdateCustomerFailure(Resource("birthday_empty") as string);
                return;
            }
            DateTime birthday2 = (DateTime)birthday;
            if (!Reg.Address.IsMatch(address))
            {
                Navigation.UpdateCustomerFailure(Resource("address_fail") as string);
                return;
            }
            if (phoneNumber == "" || !Reg.PhoneNumber.IsMatch(phoneNumber))
            {
                Navigation.UpdateCustomerFailure(Resource("phone_number_fail") as string);
                return;
            }

            dataManager.UpdateCustomer(customer, name, birthday2, address, phoneNumber)
                .WhenSuccess(data => Navigation.UpdateCustomerSuccess())
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }
    }
}
