using Manager4.core;
using Manager4.util.value;
using System;

namespace Manager4.ui.manager.customerManager.addCustomer
{
    public class AddCustomerViewModel : BaseViewModel<IAddCustomer>
    {
        public void AddCustomer(string name, DateTime? birthday, string address, string phoneNumber)
        {
            if (!Reg.Name.IsMatch(name))
            {
                Navigation.AddCustomerFailure(Resource("name_fail") as string);
                return;
            }
            if (birthday == null)
            {
                Navigation.AddCustomerFailure(Resource("birthday_empty") as string);
                return;
            }
            DateTime birthday2 = (DateTime)birthday;
            if (!Reg.Address.IsMatch(address))
            {
                Navigation.AddCustomerFailure(Resource("address_fail") as string);
                return;
            }
            if (phoneNumber == "" || !Reg.PhoneNumber.IsMatch(phoneNumber))
            {
                Navigation.AddCustomerFailure(Resource("phone_number_fail") as string);
                return;
            }

            dataManager.CreateCustomer(name, birthday2, address, phoneNumber)
                .WhenSuccess(data => Navigation.AddCustomerSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.AddCustomerFailure(Resource("unknown_error") as string);
                })
                .Call();
        }
    }
}
