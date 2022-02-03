using Manager4.util.enu;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.manager.staffManager.addStaff
{
    /// <summary>
    /// Interaction logic for AddStaffDialog.xaml
    /// </summary>
    public partial class AddStaffDialog : AddStaffView, IAddStaff
    {
        public AddStaffDialog()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbName.Focus();
        }

        protected override IAddStaff Navigation() => this;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                tbUsername.Focus();
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
                tbRole.Focus();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
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
            viewModel.AddStaff(tbName.Text.Trim(), tbBirthday.SelectedDate, tbAddress.Text.Trim(), tbPhoneNumber.Text.Trim(), tbSignature.Text.Trim(), tbUsername.Text, tbPassword.Password, tbConfirmPassword.Password, role2);
        }

        public void AddStaffSuccess()
        {
            ev.Post(EventEnum.REFRESH_STAFF, null);
            Close();
        }

        public void AddStaffFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
            tbName.Focus();
        }
    }
}
