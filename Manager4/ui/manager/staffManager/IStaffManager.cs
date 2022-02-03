using Manager4.core;
using Manager4.data.model;
using System.Collections.Generic;

namespace Manager4.ui.manager.staffManager
{
    public interface IStaffManager : INavigation
    {
        void GetAllUserSuccess(List<User> users);
        void DeleteUserSuccess();
        void DeleteUserFailure(string message);
    }
}
