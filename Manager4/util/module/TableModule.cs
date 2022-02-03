using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Manager4.util.module
{
    public class TableModule<T>
        where T : class
    {
        public ObservableCollection<T> Items { get; set; }

        public TableModule()
        {
            Items = new ObservableCollection<T>();
        }

        public void Refresh(List<T> list)
        {
            Items.Clear();
            foreach (T item in list)
            {
                Items.Add(item);
            }
        }
    }
}
