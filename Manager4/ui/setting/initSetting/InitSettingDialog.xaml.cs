using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager4.ui.setting.initSetting
{
    /// <summary>
    /// Interaction logic for InitSettingDialog.xaml
    /// </summary>
    public partial class InitSettingDialog : InitSettingView, IInitSetting
    {
        public InitSettingDialog()
        {
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            tbConnection.Focus();
        }

        protected override IInitSetting Navigation() => this;

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            viewModel.TestConnection(tbConnection.Text);
        }

        private void btnInit_Click(object sender, RoutedEventArgs e)
        {
            viewModel.InitDB(tbConnection.Text);
        }

        public void TestConnectionSuccess()
        {
            MessageBox.Show(Resource("test_connection_success") as string, Resource("success") as string, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void TestConnectionFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void InitDBSuccess()
        {
            MessageBox.Show((Resource("restart_warning") as string).Replace("!0!", "\n"), Resource("success") as string, MessageBoxButton.OK, MessageBoxImage.Warning);
            Close();
        }

        public void InitDBFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
