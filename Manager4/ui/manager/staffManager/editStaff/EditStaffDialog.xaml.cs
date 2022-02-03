using Manager4.data.model;
using Manager4.util.enu;
using System;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.manager.staffManager.editStaff
{
    /// <summary>
    /// Interaction logic for EditStaffDialog.xaml
    /// </summary>
    public partial class EditStaffDialog : EditStaffView, IEditStaff
    {
        private User _user;
        private bool isEditSuccess = false;

        public EditStaffDialog(User user)
        {
            _user = user;
            InitializeComponent();
            Setup();
        }

        public void UpdateAccountInfoFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void UpdateAccountInfoSuccess(User user)
        {
            isEditSuccess = true;
            MessageBox.Show(Resource("edit_staff_success") as string, Resource("success") as string, MessageBoxButton.OK, MessageBoxImage.Information);
            _user = user;
            InitUI();
        }

        public void UpdateBasicInfoFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void UpdateBasicInfoSuccess(User user)
        {
            isEditSuccess = true;
            MessageBox.Show(Resource("edit_staff_success") as string, Resource("success") as string, MessageBoxButton.OK, MessageBoxImage.Information);
            _user = user;
            InitUI();
        }

        protected override void InitUI()
        {
            tbName.Focus();
            tbName.Text = _user.Name;
            tbBirthday.Text = _user.Birthday.ToString("dd/MM/yyyy");
            tbAddress.Text = _user.Address;
            tbPhoneNumber.Text = _user.PhoneNumber;
            tbSignature.Text = _user.Signature;
            tbRole.SelectedIndex = (int)_user.Role;
            tbUsername.Text = _user.UserName;
            tbPassword.Clear();
            tbConfirmPassword.Clear();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (isEditSuccess)
            {
                ev.Post(EventEnum.REFRESH_STAFF, null);
            }
        }

        protected override IEditStaff Navigation() => this;

        private void btnUpdateBasicInfo_Click(object sender, RoutedEventArgs e)
        {
            RoleEnum role2 = RoleEnum.ADMIN;
            switch (tbRole.SelectedIndex)
            {
                case 0:
                    {
                        role2 = RoleEnum.ADMIN;
                        break;
                    }
                case 1:
                    {
                        role2 = RoleEnum.MANAGER;
                        break;
                    }
                case 2:
                    {
                        role2 = RoleEnum.STAFF;
                        break;
                    }
            }
            viewModel.UpdateBasicInfo(_user, tbName.Text.Trim(), tbBirthday.SelectedDate, tbAddress.Text.Trim(), tbPhoneNumber.Text.Trim(), tbSignature.Text.Trim(), role2);
        }

        private void btnUpdateAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateAccountInfo(_user, tbUsername.Text, tbPassword.Password, tbConfirmPassword.Password);
        }

        private void tbName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbBirthday.Focus();
            }
        }

        private void tbBirthday_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbAddress.Focus();
            }
        }

        private void tbAddress_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbPhoneNumber.Focus();
            }
        }

        private void tbPhoneNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbSignature.Focus();
            }
        }

        private void tbSignature_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbRole.Focus();
            }
        }

        private void tbUsername_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbPassword.Focus();
            }
        }

        private void tbPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbConfirmPassword.Focus();
            }
        }

        private void tbConfirmPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnUpdateAccountInfo_Click(sender, e);
            }
        }
    }
}
