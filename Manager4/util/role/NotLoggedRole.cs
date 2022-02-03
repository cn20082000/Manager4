using Manager4.core;
using Manager4.util.enu;

namespace Manager4.util.role
{
    public class NotLoggedRole : IPermission
    {
        public bool CreateStaff() => false;

        public bool DeleteStaff() => false;

        public bool EditStaff() => false;

        public bool MenuGeneral() => true;

        public bool MenuLogin() => true;

        public bool MenuLogout() => false;

        public bool MenuManager() => false;

        public bool MenuManCustomer() => false;

        public bool MenuManStaff() => false;

        public bool MenuSetting() => false;

        public bool MenuSettingBasic() => false;

        public bool MenuStatistic() => false;

        public bool MenuUserInfo() => false;

        public RoleEnum Name() => RoleEnum.NOTLOGGED;

        public bool SearchAll() => false;

        public bool ViewStaff() => false;
    }
}
