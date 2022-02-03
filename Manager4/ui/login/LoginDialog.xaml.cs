using Manager4.data.model;
using Manager4.util.enu;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.login
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : LoginView, ILogin
    {
        public LoginDialog()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbUsername.Focus();
        }

        protected override ILogin Navigation() => this;

        private void tbUsername_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                tbPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Login(tbUsername.Text, tbPassword.Password);
        }

        private void tbPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnLogin_Click(sender, e);
            }
        }

        public void LoginSuccess(User user)
        {
            App.User = user;
            role.ChangeRole(user.Role);
            ev.Post(EventEnum.REFRESH_ROLE, null);
            Close();
        }

        public void LoginFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
            tbUsername.Focus();
        }
    }
}
