using Manager4.core;
using Manager4.util.enu;

namespace Manager4.util.role
{
    public class StaffRole : IPermission
    {
        public bool CreateStaff() => false;

        public bool DeleteStaff() => false;

        public bool EditStaff() => false;

        public bool MenuGeneral() => true;

        public bool MenuLogin() => false;

        public bool MenuLogout() => true;

        public bool MenuManager() => false;

        public bool MenuManCustomer() => false;

        public bool MenuManStaff() => false;

        public bool MenuSetting() => false;

        public bool MenuSettingBasic() => false;

        public bool MenuStatistic() => false;

        public bool MenuUserInfo() => true;

        public RoleEnum Name() => RoleEnum.STAFF;

        public bool SearchAll() => true;

        public bool ViewStaff() => false;
    }
}
