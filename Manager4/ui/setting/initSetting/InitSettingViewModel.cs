using Manager4.common;
using Manager4.core;
using Manager4.data;
using Manager4.util;
using Manager4.util.enu;
using Manager4.util.obj;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager4.ui.setting.initSetting
{
    public class InitSettingViewModel : BaseViewModel<IInitSetting>
    {
        public void TestConnection(string str)
        {
            try
            {
                var conn = new SqlConnection(str);
                conn.Open();
                conn.Close();
                Navigation.TestConnectionSuccess();
            }
            catch (Exception)
            {
                Navigation.TestConnectionFailure(Resource("test_connection_fail") as string);
            }
        }

        public void InitDB(string str)
        {
            try
            {
                var conn = new SqlConnection(str);
                conn.Open();
                conn.Close();
                
                Setting s = new Setting();
                s.ConnectionString = str;
                s.Contact1 = "Contact 1";
                s.Contact2 = "Contact 2";

                App.setting = s;
                App.Db = new DatabaseContext();
                dataManager = new DataManagerImpl();

                dataManager.CreateUser("admin", DateTime.Now, "", "", "", "admin", "admin", RoleEnum.ADMIN)
                    .WhenSuccess(data =>
                    {
                        FileIO.WriteObject("main.json", s);
                        Navigation.InitDBSuccess();
                    })
                    .WhenFailure(error =>
                    {
                        Console.WriteLine(error);
                        Navigation.InitDBFailure(Resource("init_fail") as string);
                    })
                    .Call();

                
            }
            catch (Exception)
            {
                Navigation.TestConnectionFailure(Resource("test_connection_fail") as string);
            }
        }
    }
}
