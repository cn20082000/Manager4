using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.info.changePassword
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : ChangePasswordView, IChangePassword
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
            Setup();
        }

        public void ChangePasswordFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
            tbOldPassword.Focus();
        }

        public void ChangePasswordSuccess()
        {
            MessageBox.Show(Resource("change_password_success") as string, Resource("success") as string, MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        protected override void InitUI()
        {
            tbUsername.Text = App.User.UserName;
            tbOldPassword.Focus();
        }

        protected override IChangePassword Navigation() => this;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbOldPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbNewPassword.Focus();
            }
        }

        private void tbNewPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbConfirmPassword.Focus();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ChangePassword(tbOldPassword.Password, tbNewPassword.Password, tbConfirmPassword.Password);
        }

        private void tbConfirmPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnUpdate_Click(sender, e);
            }
        }
    }
}
