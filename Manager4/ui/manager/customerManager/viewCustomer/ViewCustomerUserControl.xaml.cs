using Manager4.core;
using Manager4.data.model;
using Manager4.ui.prescription.preview;
using Manager4.util.module;
using Manager4.util.obj;
using System.Collections.Generic;

namespace Manager4.ui.manager.customerManager.viewCustomer
{
    /// <summary>
    /// Interaction logic for ViewCustomerUserControl.xaml
    /// </summary>
    public partial class ViewCustomerUserControl : ViewCustomerView, IViewCustomer
    {
        private Customer _customer;
        private TableModule<PrescriptionRow> tableModule;

        public ViewCustomerUserControl(Customer customer)
        {
            _customer = customer;
            InitializeComponent();
            Setup();
        }

        public void GetPrescriptionSuccess(List<Prescription> list)
        {
            List<PrescriptionRow> prescriptionRows = new List<PrescriptionRow>();
            for (int i = 0; i < list.Count; i++)
            {
                Prescription prescription = list[i];
                PrescriptionRow row = new PrescriptionRow();
                row.Index = i + 1;
                row.Key = "M" + prescription.Key;
                row.Time = prescription.Time.ToString("HH:mm:ss dd/MM/yyyy");
                row.User = prescription.User.Name;
                row.Payment = string.Format("{0:N0}", prescription.Payment) + " " + Resource("vnd");
                row.ViewCommand = new RelayCommand(o =>
                {
                    PreviewWindow window = new PreviewWindow(prescription);
                    window.Show();
                });
                prescriptionRows.Add(row);
            }
            tableModule.Refresh(prescriptionRows);
        }

        protected override void InitUI()
        {
            tblName.Text = Resource("name") as string + ": " + _customer.Name;
            tblBirthday.Text = Resource("birthday") as string + ": " + _customer.Birthday.ToString("dd/MM/yyyy");
            tblAddress.Text = Resource("address") as string + ": " + _customer.Address;
            tblPhoneNumber.Text = Resource("phone_number") as string + ": " + _customer.PhoneNumber;
            tableModule = new TableModule<PrescriptionRow>();
            tablePrescription.ItemsSource = tableModule.Items;
            viewModel.GetPrescription(_customer);
        }

        protected override IViewCustomer Navigation() => this;
    }
}
