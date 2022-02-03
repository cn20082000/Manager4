using Manager4.common;
using Manager4.core;
using Manager4.data.model;
using Manager4.ui.manager.staffManager.addStaff;
using Manager4.ui.manager.staffManager.editStaff;
using Manager4.ui.manager.staffManager.viewStaff;
using Manager4.util.enu;
using Manager4.util.module;
using Manager4.util.obj;
using System.Collections.Generic;
using System.Windows;

namespace Manager4.ui.manager.staffManager
{
    /// <summary>
    /// Interaction logic for StaffManagerUserControl.xaml
    /// </summary>
    public partial class StaffManagerUserControl : StaffManagerView, IStaffManager
    {
        private TableModule<StaffRow> tableModule;

        public StaffManagerUserControl()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tableModule = new TableModule<StaffRow>();
            tableStaff.ItemsSource = tableModule.Items;
            viewModel.GetAllUser();
        }

        protected override void RefreshRole()
        {
            btnAdd.Visibility = role.Permission.CreateStaff() ? Visibility.Visible : Visibility.Collapsed;
        }

        protected override void RegisterEvent()
        {
            RegisterEvent(EventEnum.REFRESH_STAFF, o => viewModel.GetAllUser());
        }

        protected override IStaffManager Navigation() => this;

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStaffDialog dialog = new AddStaffDialog();
            dialog.ShowDialog();
        }

        public void GetAllUserSuccess(List<User> users)
        {
            List<StaffRow> staffRows = new List<StaffRow>();
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                StaffRow row = new StaffRow();
                row.Index = i + 1;
                row.Name = user.Name;
                row.Birthday = user.Birthday.ToString("dd/MM/yyyy");
                row.PhoneNumber = user.PhoneNumber;
                row.Role = RoleCenter.GetName(user.Role);
                row.CanView = role.Permission.ViewStaff() ? Visibility.Visible : Visibility.Collapsed;
                row.CanEdit = role.Permission.EditStaff() ? Visibility.Visible : Visibility.Collapsed;
                row.CanDelete = role.Permission.DeleteStaff() ? Visibility.Visible : Visibility.Collapsed;
                row.ViewCommand = new RelayCommand(o =>
                {
                    ViewStaffDialog dialog = new ViewStaffDialog(user);
                    dialog.ShowDialog();
                });
                row.EditCommand = new RelayCommand(o =>
                {
                    EditStaffDialog dialog = new EditStaffDialog(user);
                    dialog.ShowDialog();
                });
                row.DeleteCommand = new RelayCommand(o =>
                {
                    MessageBoxResult result = MessageBox.Show((Resource("delete_staff_confirm") as string).Replace("!0!", user.Name), Resource("delete_staff") as string,
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        viewModel.DeleteUser(user);
                    }
                });
                staffRows.Add(row);
            }
            tableModule.Refresh(staffRows);
        }

        public void DeleteUserSuccess()
        {
            viewModel.GetAllUser();
        }

        public void DeleteUserFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
