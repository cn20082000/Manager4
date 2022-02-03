using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.module;
using Manager4.util.obj;
using System.Collections.Generic;
using System.Windows;

namespace Manager4.ui.manager.statistic
{
    /// <summary>
    /// Interaction logic for StatisticUserControl.xaml
    /// </summary>
    public partial class StatisticUserControl : StatisticView, IStatistic
    {
        private TableModule<StaPrescriptionRow> tableModule;

        public StatisticUserControl()
        {
            InitializeComponent();
            Setup();
        }

        public void StatisticPrescriptionFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void StatisticPrescriptionSuccess(List<StaPrescription> list)
        {
            List<StaPrescriptionRow> staRows = new List<StaPrescriptionRow>();
            for (int i = 0; i < list.Count; i++)
            {
                StaPrescription sta = list[i];
                StaPrescriptionRow row = new StaPrescriptionRow();
                row.Index = i + 1;
                row.Time = sta.Time;
                row.Payment = string.Format("{0:N0}", sta.Payment) + " " + Resource("vnd");
                row.Count = sta.Count;
                staRows.Add(row);
            }
            tableModule.Refresh(staRows);
        }

        protected override void InitUI()
        {
            tableModule = new TableModule<StaPrescriptionRow>();
            tableStatistic.ItemsSource = tableModule.Items;
        }

        protected override IStatistic Navigation() => this;

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StatisticEnum type = StatisticEnum.BY_MONTH;
            switch (cbType.SelectedIndex)
            {
                case 0:
                    {
                        type = StatisticEnum.BY_YEAR;
                        break;
                    }
                case 1:
                    {
                        type = StatisticEnum.BY_MONTH;
                        break;
                    }
                case 2:
                    {
                        type = StatisticEnum.BY_DAY;
                        break;
                    }
            }
            viewModel.StatisticPrescription(tbStartDate.SelectedDate, tbEndDate.SelectedDate, type);
        }
    }
}
