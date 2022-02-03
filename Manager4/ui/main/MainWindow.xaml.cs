using FontAwesome5;
using Manager4.common;
using Manager4.data.model;
using Manager4.ui.info;
using Manager4.ui.login;
using Manager4.ui.manager.customerManager;
using Manager4.ui.manager.customerManager.viewCustomer;
using Manager4.ui.manager.staffManager;
using Manager4.ui.manager.statistic;
using Manager4.ui.prescription;
using Manager4.ui.prescription.preview;
using Manager4.ui.search.searchCustomer;
using Manager4.ui.search.searchPrescription;
using Manager4.ui.setting.basicSetting;
using Manager4.ui.setting.initSetting;
using Manager4.util;
using Manager4.util.enu;
using Manager4.util.module;
using Manager4.util.obj;
using System;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MainView, IMain
    {
        public static RoutedCommand SearchCommand = new RoutedCommand();
        private TabModule tabModule;

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            SearchCommand.InputGestures.Add(new KeyGesture(Key.F2));
            tabModule = new TabModule();
            tab.ItemsSource = tabModule.Tabs;

            try
            {
                Setting s = FileIO.ReadObject<Setting>("main.json");
                App.setting = s;
                App.Db = new DatabaseContext();
            }
            catch (Exception)
            {
                InitSettingDialog dialog = new InitSettingDialog();
                dialog.ShowDialog();
                Close();
            }

            tblContact1.Text = App.setting.Contact1;
            tblContact2.Text = App.setting.Contact2;
        }

        protected override void RegisterEvent()
        {
            RegisterEvent(EventEnum.REFRESH_ROLE, obj => RefreshRole());
            RegisterEvent(EventEnum.SELECTED_CUSTOMER, obj =>
            {
                tabModule.Add(EFontAwesomeIcon.Regular_File, ((Customer)obj).Name, new NewPrescriptionUserControl((Customer)obj));
                tab.SelectedIndex = tabModule.Tabs.Count - 1;
            });
            RegisterEvent(EventEnum.NEW_PRES_SUCCESS, obj =>
            {
                tab.SelectedIndex = tabModule.Remove(tab.SelectedIndex);
            });
            RegisterEvent(EventEnum.VIEW_CUSTOMER, obj =>
            {
                tabModule.Add(EFontAwesomeIcon.Solid_User, ((Customer)obj).Name, new ViewCustomerUserControl((Customer)obj));
                tab.SelectedIndex = tabModule.Tabs.Count - 1;
            });
            RegisterEvent(EventEnum.SELECTED_PRESCRIPTION, obj =>
            {
                PreviewWindow window = new PreviewWindow((Prescription)obj);
                window.Show();
            });
        }

        protected override void RefreshRole()
        {
            if (role.Role == RoleEnum.NOTLOGGED)
            {
                LoginDialog dialog = new LoginDialog();
                dialog.ShowDialog();
            }
            menuGeneral.IsEnabled = role.Permission.MenuGeneral();
            menuUserInfo.IsEnabled = role.Permission.MenuUserInfo();
            menuLogin.IsEnabled = role.Permission.MenuLogin();
            menuLogout.IsEnabled = role.Permission.MenuLogout();
            menuManager.IsEnabled = role.Permission.MenuManager();
            menuManCustomer.IsEnabled = role.Permission.MenuManCustomer();
            menuManStaff.IsEnabled = role.Permission.MenuManStaff();
            menuStatistic.IsEnabled = role.Permission.MenuStatistic();
            menuSetting.IsEnabled = role.Permission.MenuSetting();
            tbSearch.IsEnabled = role.Permission.SearchAll();
            btnSearch.IsEnabled = role.Permission.SearchAll();
        }

        protected override IMain Navigation() => this;

        private void menuLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginDialog dialog = new LoginDialog();
            dialog.ShowDialog();
        }

        private void menuLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(Resource("logout_warning") as string, Resource("logout") as string, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                tabModule.Clear();
                App.User = null;
                role.ChangeRole(RoleEnum.NOTLOGGED);
                ev.Post(EventEnum.REFRESH_ROLE, null);
            }
        }

        private void menuUserInfo_Click(object sender, RoutedEventArgs e)
        {
            UserInfoDialog dialog = new UserInfoDialog();
            dialog.ShowDialog();
        }

        private void menuManStaff_Click(object sender, RoutedEventArgs e)
        {
            tabModule.Add(EFontAwesomeIcon.Solid_UsersCog, Resource("manager_staff") as string, new StaffManagerUserControl());
            tab.SelectedIndex = tabModule.Tabs.Count - 1;
        }

        private void menuManCustomer_Click(object sender, RoutedEventArgs e)
        {
            tabModule.Add(EFontAwesomeIcon.Solid_Users, Resource("manager_customer") as string, new CustomerManagerUserControl());
            tab.SelectedIndex = tabModule.Tabs.Count - 1;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tbSearch.Focus();
        }

        private void tbSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetSearch(tbSearch.Text.Trim());
        }

        public void GetSearchSuccess(SearchEnum type, string key)
        {
            switch (type)
            {
                case SearchEnum.NAME_CUSTOMER:
                case SearchEnum.PHONE_NUMBER_CUSTOMER:
                    {
                        SearchCustomerDialog dialog = new SearchCustomerDialog(type, key);
                        dialog.ShowDialog();
                        break;
                    }
                case SearchEnum.PRESCRIPTION_KEY:
                    {
                        SearchPrescriptionDialog dialog = new SearchPrescriptionDialog(key);
                        dialog.ShowDialog();
                        break;
                    }
            }
            tbSearch.Clear();
        }

        public void GetSearchFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
            tbSearch.Focus();
        }

        private void menuStatistic_Click(object sender, RoutedEventArgs e)
        {
            tabModule.Add(EFontAwesomeIcon.Regular_ChartBar, Resource("statistic") as string, new StatisticUserControl());
            tab.SelectedIndex = tabModule.Tabs.Count - 1;
        }

        private void menuSettingBasic_Click(object sender, RoutedEventArgs e)
        {
            BasicSettingDialog dialog = new BasicSettingDialog();
            dialog.ShowDialog();
        }
    }
}
