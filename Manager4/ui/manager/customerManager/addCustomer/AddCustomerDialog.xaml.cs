using Manager4.data.model;
using Manager4.util.enu;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.manager.customerManager.addCustomer
{
    /// <summary>
    /// Interaction logic for AddCustomerDialog.xaml
    /// </summary>
    public partial class AddCustomerDialog : AddCustomerView, IAddCustomer
    {
        private bool _isNewPres;
        public AddCustomerDialog(bool isNewPres = false)
        {
            _isNewPres = isNewPres;
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbName.Focus();
        }

        protected override IAddCustomer Navigation() => this;

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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddCustomer(tbName.Text.Trim(), tbBirthday.SelectedDate, tbAddress.Text.Trim(), tbPhoneNumber.Text.Trim());
        }

        private void tbPhoneNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnAdd_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void AddCustomerSuccess(Customer customer)
        {
            ev.Post(EventEnum.REFRESH_CUSTOMER, null);
            if (_isNewPres)
            {
                ev.Post(EventEnum.SELECTED_CUSTOMER, customer);
            }
            Close();
        }

        public void AddCustomerFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
