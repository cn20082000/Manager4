using Manager4.core;
using Manager4.data.model;

namespace Manager4.ui.manager.staffManager.editStaff
{
    public interface IEditStaff : INavigation
    {
        void UpdateBasicInfoSuccess(User user);
        void UpdateBasicInfoFailure(string message);
        void UpdateAccountInfoSuccess(User user);
        void UpdateAccountInfoFailure(string message);
    }
}
