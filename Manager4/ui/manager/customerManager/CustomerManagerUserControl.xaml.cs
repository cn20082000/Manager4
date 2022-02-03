using Manager4.core;
using Manager4.data.model;
using Manager4.ui.manager.customerManager.addCustomer;
using Manager4.ui.manager.customerManager.editCustomer;
using Manager4.util.enu;
using Manager4.util.module;
using Manager4.util.obj;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Manager4.ui.manager.customerManager
{
    /// <summary>
    /// Interaction logic for CustomerManagerUserControl.xaml
    /// </summary>
    public partial class CustomerManagerUserControl : CustomerManagerView, ICustomerManager
    {
        private TableModule<CustomerRow> tableModule;
        private int _page;

        public CustomerManagerUserControl()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            SetPage(1);
            tableModule = new TableModule<CustomerRow>();
            tableCustomer.ItemsSource = tableModule.Items;
            viewModel.GetAllCustomer(1, 20, CustomerAttrEnum.ID, false);
        }

        protected override void RegisterEvent()
        {
            RegisterEvent(EventEnum.REFRESH_CUSTOMER, o => viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc()));
        }

        protected override ICustomerManager Navigation() => this;

        public void GetAllCustomerSuccess(List<Customer> list)
        {
            List<CustomerRow> customerRows = new List<CustomerRow>();
            for (int i = 0; i < list.Count; i++)
            {
                Customer customer = list[i];
                CustomerRow row = new CustomerRow();
                row.Index = (_page - 1) * GetPageSize() + i + 1;
                row.Name = customer.Name;
                row.Birthday = customer.Birthday.ToString("dd/MM/yyyy");
                row.Address = customer.Address;
                row.PhoneNumber = customer.PhoneNumber;
                row.ViewCommand = new RelayCommand(o =>
                {
                    ev.Post(EventEnum.VIEW_CUSTOMER, customer);
                });
                row.EditCommand = new RelayCommand(o =>
                {
                    EditCustomerDialog dialog = new EditCustomerDialog(customer);
                    dialog.ShowDialog();
                });
                row.DeleteCommand = new RelayCommand(o =>
                {
                    MessageBoxResult result = MessageBox.Show((Resource("delete_customer_confirm") as string).Replace("!0!", customer.Name), Resource("delete_customer") as string,
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        viewModel.DeleteCustomer(customer);
                    }
                });
                customerRows.Add(row);
            }
            tableModule.Refresh(customerRows);
        }

        private int GetPageSize()
        {
            switch (cbPageSize.SelectedIndex)
            {
                case 0: return 20;
                case 1: return 50;
                case 2: return 100;
                default: return 20;
            }
        }

        private CustomerAttrEnum GetSortBy()
        {
            switch (cbSortBy.SelectedIndex)
            {
                case 0: return CustomerAttrEnum.ID;
                case 1: return CustomerAttrEnum.NAME;
                case 2: return CustomerAttrEnum.BIRTHDAY;
                case 3: return CustomerAttrEnum.ADDRESS;
                case 4: return CustomerAttrEnum.PHONE_NUMBER;
                default: return CustomerAttrEnum.ID;
            }
        }

        private bool GetAsc()
        {
            switch (cbSortType.SelectedIndex)
            {
                case 0: return true;
                case 1: return false;
                default: return false;
            }
        }

        public void SetPage(int page)
        {
            if (page <= 1)
            {
                _page = 1;
                btnFirst.IsEnabled = false;
                btnPrev.IsEnabled = false;
            }
            else
            {
                _page = page;
                btnFirst.IsEnabled = true;
                btnPrev.IsEnabled = true;
            }
            tbPage.Text = _page.ToString();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsInitialized == true)
            {
                SetPage(1);
                viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc());
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            SetPage(1);
            viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc());
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            SetPage(_page - 1);
            viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc());
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            SetPage(_page + 1);
            viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc());
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            SetPage(_page + 5);
            viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerDialog dialog = new AddCustomerDialog();
            dialog.ShowDialog();
        }

        public void DeleteCustomerSuccess()
        {
            viewModel.GetAllCustomer(_page, GetPageSize(), GetSortBy(), GetAsc());
        }

        public void DeleteCustomerFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
