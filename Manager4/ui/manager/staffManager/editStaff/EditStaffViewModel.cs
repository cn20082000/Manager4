using Manager4.core;
using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.value;
using System;

namespace Manager4.ui.manager.staffManager.editStaff
{
    public class EditStaffViewModel : BaseViewModel<IEditStaff>
    {
        public void UpdateBasicInfo(User u, string name, DateTime? birthday, string address,
            string phoneNumber, string signature, RoleEnum role)
        {
            if (!Reg.Name.IsMatch(name))
            {
                Navigation.UpdateBasicInfoFailure(Resource("name_fail") as string);
                return;
            }
            if (birthday == null)
            {
                Navigation.UpdateBasicInfoFailure(Resource("birthday_empty") as string);
                return;
            }
            DateTime birthday2 = (DateTime)birthday;
            if (!Reg.Address.IsMatch(address))
            {
                Navigation.UpdateBasicInfoFailure(Resource("address_fail") as string);
                return;
            }
            if (phoneNumber == "" || !Reg.PhoneNumber.IsMatch(phoneNumber))
            {
                Navigation.UpdateBasicInfoFailure(Resource("phone_number_fail") as string);
                return;
            }
            if (signature == "")
            {
                Navigation.UpdateBasicInfoFailure(Resource("signature_empty") as string);
                return;
            }

            dataManager.UpdateBasicInfo(u, name, birthday2, address, phoneNumber, signature, role)
                .WhenSuccess(data => Navigation.UpdateBasicInfoSuccess(data))
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }

        public void UpdateAccountInfo(User u, string username, string password, string confirmPassword)
        {
            if (!Reg.Username.IsMatch(username))
            {
                Navigation.UpdateAccountInfoFailure(Resource("username_fail") as string);
                return;
            }
            if (!Reg.Password.IsMatch(password))
            {
                Navigation.UpdateAccountInfoFailure(Resource("password_fail") as string);
                return;
            }
            if (password != confirmPassword)
            {
                Navigation.UpdateAccountInfoFailure(Resource("confirm_password_wrong") as string);
                return;
            }

            dataManager.UpdateAccountInfo(u, username, password)
                .WhenSuccess(data => Navigation.UpdateAccountInfoSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.UpdateAccountInfoFailure(Resource("username_duplicate") as string);
                })
                .Call();
        }
    }
}
