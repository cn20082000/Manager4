using Manager4.common;
using Manager4.util.enu;
using Manager4.util.obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace Manager4.core
{
    public abstract class BaseWindow<NA, VM> : Window
        where VM : BaseViewModel<NA>, new()
        where NA : INavigation
    {
        protected VM viewModel;
        protected RoleCenter role;
        protected EventCenter ev;
        private Dictionary<EventEnum, string> events = new Dictionary<EventEnum, string>();

        protected void Setup()
        {
            if (Application.Current.MainWindow.IsVisible)
            {
                Owner = Application.Current.MainWindow;
            }
            viewModel = new VM();
            role = App.RoleCenter;
            ev = App.EventCenter;
            viewModel.Navigation = Navigation();
            Language = XmlLanguage.GetLanguage("en-GB");

            InitUI();
            RegisterEvent();
            RefreshRole();
            Closed += UnregisterEvent;
            Closed += WindowClose;
        }

        private void WindowClose(object sender, EventArgs e)
        {
            if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsVisible)
            {
                Application.Current.MainWindow.Activate();
            }
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

        private void UnregisterEvent(object sender, EventArgs e)
        {
            foreach (string id in events.Values.ToList())
            {
                ev.UnregisterEvent(id);
            }
        }
    }
}
