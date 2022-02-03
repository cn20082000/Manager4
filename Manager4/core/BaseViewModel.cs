using Manager4.data;

namespace Manager4.core
{
    public class BaseViewModel<NA>
        where NA : INavigation
    {
        private NA _navigation;
        protected IDataManager dataManager = new DataManagerImpl();

        public NA Navigation
        {
            get => _navigation;
            set => _navigation = value;
        }

        protected object Resource(string name)
        {
            return App.Current.TryFindResource(name);
        }
    }
}
