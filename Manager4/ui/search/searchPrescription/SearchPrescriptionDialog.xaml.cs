using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.module;
using Manager4.util.obj;
using System.Collections.Generic;
using System.Windows.Input;

namespace Manager4.ui.search.searchPrescription
{
    /// <summary>
    /// Interaction logic for SearchPrescriptionDialog.xaml
    /// </summary>
    public partial class SearchPrescriptionDialog : SearchPrescriptionView, ISearchPrescription
    {
        private string _key;
        public static RoutedCommand CloseCommand = new RoutedCommand();
        private TableModule<PrescriptionRow> tableModule;
        private List<Prescription> listPrescription;

        public SearchPrescriptionDialog(string key)
        {
            _key = key;
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            CloseCommand.InputGestures.Add(new KeyGesture(Key.Escape));
            tableModule = new TableModule<PrescriptionRow>();
            tablePrecription.ItemsSource = tableModule.Items;
            viewModel.FindPrescription(_key);
        }

        protected override ISearchPrescription Navigation() => this;

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        public void FindPrescriptionSuccess(List<Prescription> list)
        {
            listPrescription = list;
            List<PrescriptionRow> prescriptionRows = new List<PrescriptionRow>();
            for (int i = 0; i < list.Count; i++)
            {
                Prescription prescription = list[i];
                PrescriptionRow row = new PrescriptionRow();
                row.Key = "M" + prescription.Key;
                row.Customer = prescription.Customer.Name;
                row.Birthday = prescription.Customer.Birthday.ToString("dd/MM/yyyy");
                row.User = prescription.User.Name;
                row.Time = prescription.Time.ToString("HH:mm:ss dd/MM/yyyy");
                prescriptionRows.Add(row);
            }
            tableModule.Refresh(prescriptionRows);
            if (list.Count > 0)
            {
                tablePrecription.Focus();
                tablePrecription.SelectedIndex = 0;
            }
        }

        private void tablePrecription_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int selected = tablePrecription.SelectedIndex;
            if (e.Key == Key.Enter && selected >= 0 && selected < listPrescription.Count)
            {
                e.Handled = true;
                ev.Post(EventEnum.SELECTED_PRESCRIPTION, listPrescription[selected]);
                Close();
            }
        }
    }
}
