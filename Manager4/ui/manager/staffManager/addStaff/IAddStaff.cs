using Manager4.core;

namespace Manager4.ui.manager.staffManager.addStaff
{
    public interface IAddStaff : INavigation
    {
        void AddStaffSuccess();
        void AddStaffFailure(string message);
    }
}
