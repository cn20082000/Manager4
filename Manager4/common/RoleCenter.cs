using Manager4.core;
using Manager4.util.enu;
using Manager4.util.role;

namespace Manager4.common
{
    public class RoleCenter
    {
        private RoleEnum _role = RoleEnum.NOTLOGGED;
        private IPermission _permission = new NotLoggedRole();

        public void ChangeRole(RoleEnum role)
        {
            switch (role)
            {
                case RoleEnum.ADMIN:
                    {
                        _role = RoleEnum.ADMIN;
                        _permission = new AdminRole();
                        break;
                    }
                case RoleEnum.MANAGER:
                    {
                        _role = RoleEnum.MANAGER;
                        _permission = new ManagerRole();
                        break;
                    }
                case RoleEnum.STAFF:
                    {
                        _role = RoleEnum.STAFF;
                        _permission = new StaffRole();
                        break;
                    }
                case RoleEnum.NOTLOGGED:
                    {
                        _role = RoleEnum.NOTLOGGED;
                        _permission = new NotLoggedRole();
                        break;
                    }
            }
        }

        public RoleEnum Role
        {
            get => _role;
        }

        public string Name
        {
            get
            {
                switch (_role)
                {
                    case RoleEnum.ADMIN: return App.Current.TryFindResource("admin") as string;
                    case RoleEnum.MANAGER: return App.Current.TryFindResource("manager") as string;
                    case RoleEnum.STAFF: return App.Current.TryFindResource("staff") as string;
                    default: return "";
                }
            }
        }

        public IPermission Permission
        {
            get => _permission;
        }

        public static string GetName(RoleEnum role)
        {
            switch (role)
            {
                case RoleEnum.ADMIN: return App.Current.TryFindResource("admin") as string;
                case RoleEnum.MANAGER: return App.Current.TryFindResource("manager") as string;
                case RoleEnum.STAFF: return App.Current.TryFindResource("staff") as string;
                default: return "";
            }
        }
    }
}
