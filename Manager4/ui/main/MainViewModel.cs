using Manager4.core;
using Manager4.util.enu;
using Manager4.util.value;

namespace Manager4.ui.main
{
    public class MainViewModel : BaseViewModel<IMain>
    {
        public void GetSearch(string key)
        {
            if (Reg.Name.IsMatch(key))
            {
                Navigation.GetSearchSuccess(SearchEnum.NAME_CUSTOMER, key);
            }
            else if (Reg.PhoneNumber.IsMatch(key))
            {
                Navigation.GetSearchSuccess(SearchEnum.PHONE_NUMBER_CUSTOMER, key);
            }
            else if (Reg.KeySearch.IsMatch(key))
            {
                Navigation.GetSearchSuccess(SearchEnum.PRESCRIPTION_KEY, key.Substring(1));
            }
            else
            {
                Navigation.GetSearchFailure(Resource("unknown_search") as string);
            }
        }
    }
}
