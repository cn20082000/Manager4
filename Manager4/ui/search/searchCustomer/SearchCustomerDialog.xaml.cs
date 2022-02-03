using Manager4.data.model;
using Manager4.ui.manager.customerManager.addCustomer;
using Manager4.util.enu;
using Manager4.util.module;
using Manager4.util.obj;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Manager4.ui.search.searchCustomer
{
    /// <summary>
    /// Interaction logic for SearchCustomerDialog.xaml
    /// </summary>
    public partial class SearchCustomerDialog : SearchCustomerView, ISearchCustomer
    {
        private SearchEnum _type;
        private string _key;
        public static RoutedCommand CloseCommand = new RoutedCommand();
        private TableModule<CustomerRow> tableModule;
        private List<Customer> listCustomer;

        public SearchCustomerDialog(SearchEnum type, string key)
        {
            _type = type;
            _key = key;
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            CloseCommand.InputGestures.Add(new KeyGesture(Key.Escape));
            tableModule = new TableModule<CustomerRow>();
            tableCustomer.ItemsSource = tableModule.Items;
            viewModel.FindCustomer(_type, _key);
        }

        protected override ISearchCustomer Navigation() => this;

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        public void FindCustomerSuccess(List<Customer> list)
        {
            listCustomer = list;
            List<CustomerRow> customerRows = new List<CustomerRow>();
            for (int i = 0; i < list.Count; i++)
            {
                Customer customer = list[i];
                CustomerRow row = new CustomerRow();
                row.Name = customer.Name;
                row.Birthday = customer.Birthday.ToString("dd/MM/yyyy");
                row.Address = customer.Address;
                row.PhoneNumber = customer.PhoneNumber;
                customerRows.Add(row);
            }
            tableModule.Refresh(customerRows);
            if (list.Count > 0)
            {
                tableCustomer.Focus();
                tableCustomer.SelectedIndex = 0;
            }
        }

        private void tableCustomer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int selected = tableCustomer.SelectedIndex;
            if (e.Key == Key.Enter && selected >= 0 && selected < listCustomer.Count)
            {
                e.Handled = true;
                ev.Post(EventEnum.SELECTED_CUSTOMER, listCustomer[selected]);
                Close();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AddCustomerDialog dialog = new AddCustomerDialog(true);
            dialog.ShowDialog();
        }
    }
}
