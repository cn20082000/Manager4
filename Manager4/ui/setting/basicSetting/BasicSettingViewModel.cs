using Manager4.core;
using Manager4.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager4.ui.setting.basicSetting
{
    public class BasicSettingViewModel : BaseViewModel<IBasicSetting>
    {
        public void UpdateSetting(string contact1, string contact2)
        {
            App.setting.Contact1 = contact1;
            App.setting.Contact2 = contact2;
            try
            {
                FileIO.WriteObject("main.json", App.setting);
                Navigation.UpdateSettingSuccess();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
