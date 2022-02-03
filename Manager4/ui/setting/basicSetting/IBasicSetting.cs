using Manager4.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager4.ui.setting.basicSetting
{
    public interface IBasicSetting : INavigation
    {
        void UpdateSettingSuccess();
        void UpdateSettingFailure(string message);
    }
}
