using Manager4.util.enu;

namespace Manager4.core
{
    public interface IPermission
    {
        RoleEnum Name();
        bool MenuGeneral();
        bool MenuUserInfo();
        bool MenuLogin();
        bool MenuLogout();
        bool MenuManager();
        bool MenuManStaff();
        bool MenuManCustomer();
        bool MenuStatistic();
        bool MenuSetting();
        bool MenuSettingBasic();
        bool CreateStaff();
        bool ViewStaff();
        bool EditStaff();
        bool DeleteStaff();
        bool SearchAll();
    }
}
