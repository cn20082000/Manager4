using Manager4.core;
using Manager4.util.value;
using System;

namespace Manager4.ui.login
{
    public class LoginViewModel : BaseViewModel<ILogin>
    {
        public void Login(string username, string password)
        {
            if (!Reg.Username.IsMatch(username))
            {
                Navigation.LoginFailure(Resource("username_fail") as string);
                return;
            }
            if (!Reg.Password.IsMatch(password))
            {
                Navigation.LoginFailure(Resource("password_fail") as string);
                return;
            }

            dataManager.Login(username, password)
                .WhenSuccess(data => Navigation.LoginSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.LoginFailure(Resource("username_password_wrong") as string);
                })
                .Call();
        }
    }
}
