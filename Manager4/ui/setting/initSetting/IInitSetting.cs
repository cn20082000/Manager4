using Manager4.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager4.ui.setting.initSetting
{
    public interface IInitSetting : INavigation
    {
        void TestConnectionSuccess();
        void TestConnectionFailure(string message);
        void InitDBSuccess();
        void InitDBFailure(string message);
    }
}
