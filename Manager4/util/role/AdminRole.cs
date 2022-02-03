using Manager4.core;
using Manager4.util.enu;

namespace Manager4.util.role
{
    public class AdminRole : IPermission
    {
        public bool CreateStaff() => true;

        public bool DeleteStaff() => true;

        public bool EditStaff() => true;

        public bool MenuGeneral() => true;

        public bool MenuLogin() => false;

        public bool MenuLogout() => true;

        public bool MenuManager() => true;

        public bool MenuManCustomer() => false;

        public bool MenuManStaff() => true;

        public bool MenuSetting() => true;

        public bool MenuSettingBasic() => true;

        public bool MenuStatistic() => false;

        public bool MenuUserInfo() => true;

        public RoleEnum Name() => RoleEnum.ADMIN;

        public bool SearchAll() => false;

        public bool ViewStaff() => false;
    }
}
