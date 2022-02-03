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

namespace Manager4.ui.setting.basicSetting
{
    /// <summary>
    /// Interaction logic for BasicSettingDialog.xaml
    /// </summary>
    public partial class BasicSettingDialog : BasicSettingView, IBasicSetting
    {
        public BasicSettingDialog()
        {
            InitializeComponent();
            Setup();
        }

        public void UpdateSettingFailure(string message)
        { 
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void UpdateSettingSuccess()
        {
            MessageBox.Show(Resource("update_setting_warning") as string, Resource("success") as string, MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        protected override void InitUI()
        {
            tbContact1.Focus();
            tbContact1.Text = App.setting.Contact1;
            tbContact2.Text = App.setting.Contact2;
        }

        protected override IBasicSetting Navigation() => this;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateSetting(tbContact1.Text, tbContact2.Text);
        }
    }
}
