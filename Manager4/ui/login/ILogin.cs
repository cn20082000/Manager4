using Manager4.core;
using Manager4.data.model;

namespace Manager4.ui.login
{
    public interface ILogin : INavigation
    {
        void LoginSuccess(User user);
        void LoginFailure(string message);
    }
}
