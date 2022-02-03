using FontAwesome5;
using Manager4.core;
using Manager4.util.obj;
using System.Collections.ObjectModel;

namespace Manager4.util.module
{
    public class TabModule
    {
        public ObservableCollection<TabItem> Tabs { get; set; }

        public TabModule()
        {
            Tabs = new ObservableCollection<TabItem>();
        }

        public void Add(EFontAwesomeIcon icon, string header, BaseUnregisterEventUserControl content)
        {
            TabItem item = new TabItem();
            item.Icon = icon;
            item.Header = header;
            item.Content = content;
            item.CloseCommand = new RelayCommand(o =>
            {
                item.Content.UnregisterEvent();
                Tabs.Remove(item);
            });
            Tabs.Add(item);
        }

        public int Remove(int index)
        {
            if (index >= 0 && index < Tabs.Count)
            {
                Tabs[index].Content.UnregisterEvent();
                Tabs.RemoveAt(index);
            }

            if (index - 1 >= 0)
            {
                return index - 1;
            }
            else if (index < Tabs.Count)
            {
                return index;
            }
            return -1;
        }

        public void Clear()
        {
            Tabs.Clear();
        }
    }
}
