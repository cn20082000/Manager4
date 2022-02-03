using Manager4.common;
using Manager4.data.model;
using Manager4.util.obj;
using System.Windows;

namespace Manager4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EventCenter EventCenter = new EventCenter();
        public static RoleCenter RoleCenter = new RoleCenter();
        public static DatabaseContext Db;
        public static User User;
        public static Setting setting;
    }
}
