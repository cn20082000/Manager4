using Manager4.common;
using Manager4.util.enu;
using Manager4.util.obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Manager4.core
{
    public abstract class BaseUserControl<NA, VM> : BaseUnregisterEventUserControl
        where VM : BaseViewModel<NA>, new()
        where NA : INavigation
    {
        protected VM viewModel;
        protected RoleCenter role;
        protected EventCenter ev;
        private Dictionary<EventEnum, string> events = new Dictionary<EventEnum, string>();

        protected void Setup()
        {
            viewModel = new VM();
            role = App.RoleCenter;
            ev = App.EventCenter;
            viewModel.Navigation = Navigation();
            Language = XmlLanguage.GetLanguage("en-GB");

            InitUI();
            RegisterEvent();
            RefreshRole();
        }

        protected abstract NA Navigation();

        protected abstract void InitUI();

        protected virtual void RegisterEvent() { }

        protected virtual void RefreshRole() { }

        protected void RegisterEvent(EventEnum name, Action<object> action)
        {
            events.Add(name, ev.RegisterEvent(new Event(name, action)));
        }

        protected object Resource(string name)
        {
            return App.Current.TryFindResource(name);
        }

        public override void UnregisterEvent()
        {
            foreach (string id in events.Values.ToList())
            {
                ev.UnregisterEvent(id);
            }
        }
    }

    public abstract class BaseUnregisterEventUserControl : UserControl
    {
        public abstract void UnregisterEvent();
    }
}
