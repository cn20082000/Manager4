using Manager4.core;
using Manager4.util.enu;

namespace Manager4.util.role
{
    public class ManagerRole : IPermission
    {
        public bool CreateStaff() => false;

        public bool DeleteStaff() => false;

        public bool EditStaff() => false;

        public bool MenuGeneral() => true;

        public bool MenuLogin() => false;

        public bool MenuLogout() => true;

        public bool MenuManager() => true;

        public bool MenuManCustomer() => true;

        public bool MenuManStaff() => true;

        public bool MenuSetting() => true;

        public bool MenuSettingBasic() => true;

        public bool MenuStatistic() => true;

        public bool MenuUserInfo() => true;

        public RoleEnum Name() => RoleEnum.MANAGER;

        public bool SearchAll() => true;

        public bool ViewStaff() => true;
    }
}
