using Manager4.common;
using Manager4.data.model;

namespace Manager4.ui.manager.staffManager.viewStaff
{
    /// <summary>
    /// Interaction logic for ViewStaffDialog.xaml
    /// </summary>
    public partial class ViewStaffDialog : ViewStaffView, IViewStaff
    {
        private User _user;

        public ViewStaffDialog(User user)
        {
            _user = user;
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbName.Text = _user.Name;
            tbBirthday.Text = _user.Birthday.ToString("dd/MM/yyyy");
            tbAddress.Text = _user.Address;
            tbPhoneNumber.Text = _user.PhoneNumber;
            tbSignature.Text = _user.Signature;
            tbRole.Text = RoleCenter.GetName(_user.Role);
        }

        protected override IViewStaff Navigation() => this;
    }
}
