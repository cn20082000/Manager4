using Manager4.data.model;
using Manager4.util.enu;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.manager.customerManager.editCustomer
{
    /// <summary>
    /// Interaction logic for EditCustomerDialog.xaml
    /// </summary>
    public partial class EditCustomerDialog : EditCustomerView, IEditCustomer
    {
        private Customer _customer;

        public EditCustomerDialog(Customer customer)
        {
            _customer = customer;
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbName.Focus();
            tbName.Text = _customer.Name;
            tbBirthday.SelectedDate = _customer.Birthday;
            tbAddress.Text = _customer.Address;
            tbPhoneNumber.Text = _customer.PhoneNumber;
        }

        protected override IEditCustomer Navigation() => this;

        public void UpdateCustomerFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
            tbName.Focus();
        }

        public void UpdateCustomerSuccess()
        {
            ev.Post(EventEnum.REFRESH_CUSTOMER, null);
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
                btnUpdate_Click(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateCustomer(_customer, tbName.Text.Trim(), tbBirthday.SelectedDate, tbAddress.Text.Trim(), tbPhoneNumber.Text.Trim());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
