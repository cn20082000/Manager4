using Manager4.ui.info.changePassword;
using System.Windows;

namespace Manager4.ui.info
{
    /// <summary>
    /// Interaction logic for UserInfoDialog.xaml
    /// </summary>
    public partial class UserInfoDialog : UserInfoView, IUserInfo
    {
        public UserInfoDialog()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbName.Text = App.User.Name;
            tbBirthday.Text = App.User.Birthday.ToString("dd/MM/yyyy");
            tbAddress.Text = App.User.Address;
            tbPhoneNumber.Text = App.User.PhoneNumber;
            tbSignature.Text = App.User.Signature;
            tbRole.Text = role.Name;
        }

        protected override IUserInfo Navigation() => this;

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordDialog dialog = new ChangePasswordDialog();
            dialog.ShowDialog();
        }
    }
}
