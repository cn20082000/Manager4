using Manager4.util.enu;
using Manager4.util.obj;
using System.Collections.Generic;

namespace Manager4.common
{
    public class EventCenter
    {
        private List<Event> list = new List<Event>();

        public void Post(EventEnum name, object obj)
        {
            //foreach (Event ev in list)
            //{
            //    if (ev.Name.Equals(name))
            //    {
            //        ev.Action(obj);
            //    }
            //}
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    list[i].Action(obj);
                }
            }
        }

        public string RegisterEvent(Event e)
        {
            list.Add(e);
            return e.Id;
        }

        public void UnregisterEvent(string id)
        {
            int i;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].Id.Equals(id))
                {
                    break;
                }
            }

            if (i >= 0 && i < list.Count)
            {
                list.RemoveAt(i);
            }
        }
    }
}
