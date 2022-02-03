using Manager4.core;

namespace Manager4.ui.info.changePassword
{
    public interface IChangePassword : INavigation
    {
        void ChangePasswordSuccess();
        void ChangePasswordFailure(string message);
    }
}
