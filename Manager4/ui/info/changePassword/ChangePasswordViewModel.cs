using Manager4.core;
using Manager4.util.value;
using System;

namespace Manager4.ui.info.changePassword
{
    public class ChangePasswordViewModel : BaseViewModel<IChangePassword>
    {
        public void ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            if (!Reg.Password.IsMatch(newPassword))
            {
                Navigation.ChangePasswordFailure(Resource("password_fail") as string);
                return;
            }
            if (newPassword != confirmPassword)
            {
                Navigation.ChangePasswordFailure(Resource("confirm_password_wrong") as string);
                return;
            }

            dataManager.ChangePassword(App.User, oldPassword, newPassword)
                .WhenSuccess(data => Navigation.ChangePasswordSuccess())
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.ChangePasswordFailure(Resource("old_password_wrong") as string);
                })
                .Call();
        }
    }
}
