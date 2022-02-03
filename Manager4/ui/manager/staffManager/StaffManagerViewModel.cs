using Manager4.core;
using Manager4.data.model;
using System;

namespace Manager4.ui.manager.staffManager
{
    public class StaffManagerViewModel : BaseViewModel<IStaffManager>
    {
        public void GetAllUser()
        {
            dataManager.GetAllUser()
                .WhenSuccess(data => Navigation.GetAllUserSuccess(data))
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }

        public void DeleteUser(User user)
        {
            dataManager.DeleteUser(user)
                .WhenSuccess(data => Navigation.DeleteUserSuccess())
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.DeleteUserFailure(Resource("delete_user_fail") as string);
                })
                .Call();
        }
    }
}
