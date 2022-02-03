using Manager4.core;
using Manager4.util.enu;
using Manager4.util.value;
using System;

namespace Manager4.ui.manager.staffManager.addStaff
{
    public class AddStaffViewModel : BaseViewModel<IAddStaff>
    {
        public void AddStaff(string name, DateTime? birthday, string address, string phoneNumber,
            string signature, string username, string password, string confirmPassword, RoleEnum role2)
        {
            if (!Reg.Name.IsMatch(name))
            {
                Navigation.AddStaffFailure(Resource("name_fail") as string);
                return;
            }
            if (birthday == null)
            {
                Navigation.AddStaffFailure(Resource("birthday_empty") as string);
                return;
            }
            DateTime birthday2 = (DateTime)birthday;
            if (!Reg.Address.IsMatch(address))
            {
                Navigation.AddStaffFailure(Resource("address_fail") as string);
                return;
            }
            if (phoneNumber == "" || !Reg.PhoneNumber.IsMatch(phoneNumber))
            {
                Navigation.AddStaffFailure(Resource("phone_number_fail") as string);
                return;
            }
            if (signature == "")
            {
                Navigation.AddStaffFailure(Resource("signature_empty") as string);
                return;
            }
            if (!Reg.Username.IsMatch(username))
            {
                Navigation.AddStaffFailure(Resource("username_fail") as string);
                return;
            }
            if (!Reg.Password.IsMatch(password))
            {
                Navigation.AddStaffFailure(Resource("password_fail") as string);
                return;
            }
            if (password != confirmPassword)
            {
                Navigation.AddStaffFailure(Resource("confirm_password_wrong") as string);
                return;
            }

            dataManager.CreateUser(name, birthday2, address, phoneNumber, signature, username, password, role2)
                .WhenSuccess(data => Navigation.AddStaffSuccess())
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.AddStaffFailure(Resource("username_duplicate") as string);
                })
                .Call();
        }
    }
}
