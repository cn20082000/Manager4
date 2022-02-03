using Manager4.core;
using Manager4.util.enu;

namespace Manager4.ui.main
{
    public interface IMain : INavigation
    {
        void GetSearchSuccess(SearchEnum type, string key);
        void GetSearchFailure(string message);
    }
}
