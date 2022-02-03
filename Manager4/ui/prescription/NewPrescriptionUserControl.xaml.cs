using Manager4.data.model;
using Manager4.util.enu;
using System.Windows;

namespace Manager4.ui.prescription
{
    /// <summary>
    /// Interaction logic for NewPrescriptionUserControl.xaml
    /// </summary>
    public partial class NewPrescriptionUserControl : NewPrescriptionView, INewPrescription
    {
        private Customer _customer;
        private bool hasCustomReport = false;
        private bool isOldLeftAx = false;
        private bool isOldRightAx = false;
        private bool isNewLeftAx = false;
        private bool isNewRightAx = false;
        private Report _oldReport;

        public NewPrescriptionUserControl(Customer customer)
        {
            _customer = customer;
            InitializeComponent();
            Setup();
        }

        public void GetLastPrescriptionFailure(string message)
        {
            GetUpdateUI();
        }

        public void GetLastPrescriptionSuccess(Prescription oldPrescription)
        {
            _oldReport = oldPrescription.NewReport;

            tbOldLeftSph.Value = (decimal?)_oldReport.LeftEye.Sph;
            tbOldLeftCyl.Value = (decimal?)_oldReport.LeftEye.Cyl;
            tbOldLeftAx.Value = _oldReport.LeftEye.Ax;
            tbOldLeftAdd.Value = (decimal?)_oldReport.LeftEye.Add;
            tbOldLeftVa.Value = _oldReport.LeftEye.Va;
            tbOldLeftFh.Value = _oldReport.LeftEye.Fh;
            tbOldLeftPd2.Value = (decimal?)_oldReport.LeftEye.Pd2;
            tbOldLeftPd.Value = (decimal?)_oldReport.LeftEye.Pd;

            tbOldRightSph.Value = (decimal?)_oldReport.RightEye.Sph;
            tbOldRightCyl.Value = (decimal?)_oldReport.RightEye.Cyl;
            tbOldRightAx.Value = _oldReport.RightEye.Ax;
            tbOldRightAdd.Value = (decimal?)_oldReport.RightEye.Add;
            tbOldRightVa.Value = _oldReport.RightEye.Va;
            tbOldRightFh.Value = _oldReport.RightEye.Fh;
            tbOldRightPd2.Value = (decimal?)_oldReport.RightEye.Pd2;
            tbOldRightPd.Value = (decimal?)_oldReport.RightEye.Pd;

            tbOldDistance.IsChecked = _oldReport.Distance;
            tbOldNeutral.IsChecked = _oldReport.Neutral;
            tbOldReading.IsChecked = _oldReport.Reading;

            GetUpdateUI();
        }

        protected override void InitUI()
        {
            tblName.Text = Resource("name") as string + ": " + _customer.Name;
            tblBirthday.Text = Resource("birthday") as string + ": " + _customer.Birthday.ToString("dd/MM/yyyy");
            tblAddress.Text = Resource("address") as string + ": " + _customer.Address;
            tblPhoneNumber.Text = Resource("phone_number") as string + ": " + _customer.PhoneNumber;
            viewModel.GetLastPrescription(_customer);
        }

        private void GetUpdateUI()
        {
            btnEdit.Content = hasCustomReport ? Resource("recover") : Resource("edit");
            tbOldLeftSph.IsEnabled = hasCustomReport;
            tbOldLeftCyl.IsEnabled = hasCustomReport;
            tbOldLeftAx.IsEnabled = hasCustomReport && isOldLeftAx;
            tbOldLeftAdd.IsEnabled = hasCustomReport;
            tbOldLeftVa.IsEnabled = hasCustomReport;
            tbOldLeftFh.IsEnabled = hasCustomReport;
            tbOldLeftPd2.IsEnabled = hasCustomReport;

            tbOldRightSph.IsEnabled = hasCustomReport;
            tbOldRightCyl.IsEnabled = hasCustomReport;
            tbOldRightAx.IsEnabled = hasCustomReport && isOldRightAx;
            tbOldRightAdd.IsEnabled = hasCustomReport;
            tbOldRightVa.IsEnabled = hasCustomReport;
            tbOldRightFh.IsEnabled = hasCustomReport;
            tbOldRightPd2.IsEnabled = hasCustomReport;

            tbOldDistance.IsEnabled = hasCustomReport;
            tbOldNeutral.IsEnabled = hasCustomReport;
            tbOldReading.IsEnabled = hasCustomReport;

            tbNewLeftAx.IsEnabled = isNewLeftAx;
            tbNewRightAx.IsEnabled = isNewRightAx;
        }

        protected override INewPrescription Navigation() => this;

        private void tbOldLeftCyl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsInitialized)
            {

                if (tbOldLeftCyl.Value != null && tbOldLeftCyl.Value != 0)
                {
                    isOldLeftAx = true;
                }
                else
                {
                    isOldLeftAx = false;
                    tbOldLeftAx.Value = 0;
                }
                GetUpdateUI();
            }
        }

        private void tbOldRightCyl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsInitialized)
            {

                if (tbOldRightCyl.Value != null && tbOldRightCyl.Value != 0)
                {
                    isOldRightAx = true;
                }
                else
                {
                    isOldRightAx = false;
                    tbOldRightAx.Value = 0;
                }
                GetUpdateUI();
            }
        }

        private void tbNewLeftCyl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsInitialized)
            {

                if (tbNewLeftCyl.Value != null && tbNewLeftCyl.Value != 0)
                {
                    isNewLeftAx = true;
                }
                else
                {
                    isNewLeftAx = false;
                    tbNewLeftAx.Value = 0;
                }
                GetUpdateUI();
            }
        }

        private void tbNewRightCyl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsInitialized)
            {

                if (tbNewRightCyl.Value != null && tbNewRightCyl.Value != 0)
                {
                    isNewRightAx = true;
                }
                else
                {
                    isNewRightAx = false;
                    tbNewRightAx.Value = 0;
                }
                GetUpdateUI();
            }
        }

        private void tbOldPd2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsInitialized)
            {

                float pd21 = tbOldLeftPd2.Value != null ? (float)tbOldLeftPd2.Value : 0;
                float pd22 = tbOldRightPd2.Value != null ? (float)tbOldRightPd2.Value : 0;

                tbOldLeftPd.Value = (decimal?)(pd21 + pd22);
                tbOldRightPd.Value = (decimal?)(pd21 + pd22);
            }
        }

        private void tbNewPd2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsInitialized)
            {

                float pd21 = tbNewLeftPd2.Value != null ? (float)tbNewLeftPd2.Value : 0;
                float pd22 = tbNewRightPd2.Value != null ? (float)tbNewRightPd2.Value : 0;

                tbNewLeftPd.Value = (decimal?)(pd21 + pd22);
                tbNewRightPd.Value = (decimal?)(pd21 + pd22);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            hasCustomReport = !hasCustomReport;
            if (!hasCustomReport)
            {
                if (_oldReport != null)
                {
                    tbOldLeftSph.Value = (decimal?)_oldReport.LeftEye.Sph;
                    tbOldLeftCyl.Value = (decimal?)_oldReport.LeftEye.Cyl;
                    tbOldLeftAx.Value = _oldReport.LeftEye.Ax;
                    tbOldLeftAdd.Value = (decimal?)_oldReport.LeftEye.Add;
                    tbOldLeftVa.Value = _oldReport.LeftEye.Va;
                    tbOldLeftFh.Value = _oldReport.LeftEye.Fh;
                    tbOldLeftPd2.Value = (decimal?)_oldReport.LeftEye.Pd2;
                    tbOldLeftPd.Value = (decimal?)_oldReport.LeftEye.Pd;

                    tbOldRightSph.Value = (decimal?)_oldReport.RightEye.Sph;
                    tbOldRightCyl.Value = (decimal?)_oldReport.RightEye.Cyl;
                    tbOldRightAx.Value = _oldReport.RightEye.Ax;
                    tbOldRightAdd.Value = (decimal?)_oldReport.RightEye.Add;
                    tbOldRightVa.Value = _oldReport.RightEye.Va;
                    tbOldRightFh.Value = _oldReport.RightEye.Fh;
                    tbOldRightPd2.Value = (decimal?)_oldReport.RightEye.Pd2;
                    tbOldRightPd.Value = (decimal?)_oldReport.RightEye.Pd;

                    tbOldDistance.IsChecked = _oldReport.Distance;
                    tbOldNeutral.IsChecked = _oldReport.Neutral;
                    tbOldReading.IsChecked = _oldReport.Reading;
                }
                else
                {
                    tbOldLeftSph.Value = 0;
                    tbOldLeftCyl.Value = 0;
                    tbOldLeftAx.Value = 0;
                    tbOldLeftAdd.Value = 0;
                    tbOldLeftVa.Value = 10;
                    tbOldLeftFh.Value = 0;
                    tbOldLeftPd2.Value = 0;
                    tbOldLeftPd.Value = 0;

                    tbOldRightSph.Value = 0;
                    tbOldRightCyl.Value = 0;
                    tbOldRightAx.Value = 0;
                    tbOldRightAdd.Value = 0;
                    tbOldRightVa.Value = 10;
                    tbOldRightFh.Value = 0;
                    tbOldRightPd2.Value = 0;
                    tbOldRightPd.Value = 0;

                    tbOldDistance.IsChecked = false;
                    tbOldNeutral.IsChecked = false;
                    tbOldReading.IsChecked = false;
                }
            }
            GetUpdateUI();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            EyewearEnum eyewear = EyewearEnum.SINGLE;
            switch (cbEyewear.SelectedIndex)
            {
                case 0:
                    {
                        eyewear = EyewearEnum.SINGLE;
                        break;
                    }
                case 1:
                    {
                        eyewear = EyewearEnum.BIOFOCAL;
                        break;
                    }
                case 2:
                    {
                        eyewear = EyewearEnum.PROGRESSIVE;
                        break;
                    }
                case 3:
                    {
                        eyewear = EyewearEnum.EYEWEAR_SET;
                        break;
                    }
            }
            if (hasCustomReport)
            {
                viewModel.CreatePrescription(eyewear, tbNote.Text.Trim(), tbReExam.Value, tbPayment.Value,
                    tbOldLeftSph.Value, tbOldLeftCyl.Value, tbOldLeftAx.Value, tbOldLeftAdd.Value, tbOldLeftVa.Value, tbOldLeftFh.Value, tbOldLeftPd2.Value, tbOldLeftPd.Value,
                    tbOldRightSph.Value, tbOldRightCyl.Value, tbOldRightAx.Value, tbOldRightAdd.Value, tbOldRightVa.Value, tbOldRightFh.Value, tbOldRightPd2.Value, tbOldRightPd.Value,
                    tbOldDistance.IsChecked, tbOldNeutral.IsChecked, tbOldReading.IsChecked,
                    tbNewLeftSph.Value, tbNewLeftCyl.Value, tbNewLeftAx.Value, tbNewLeftAdd.Value, tbNewLeftVa.Value, tbNewLeftFh.Value, tbNewLeftPd2.Value, tbNewLeftPd.Value,
                    tbNewRightSph.Value, tbNewRightCyl.Value, tbNewRightAx.Value, tbNewRightAdd.Value, tbNewRightVa.Value, tbNewRightFh.Value, tbNewRightPd2.Value, tbNewRightPd.Value,
                    tbNewDistance.IsChecked, tbNewNeutral.IsChecked, tbNewReading.IsChecked, App.User, _customer);
            }
            else
            {
                if (_oldReport != null)
                {
                    viewModel.CreatePrescription(eyewear, tbNote.Text.Trim(), tbReExam.Value, tbPayment.Value, _oldReport,
                        tbNewLeftSph.Value, tbNewLeftCyl.Value, tbNewLeftAx.Value, tbNewLeftAdd.Value, tbNewLeftVa.Value, tbNewLeftFh.Value, tbNewLeftPd2.Value, tbNewLeftPd.Value,
                        tbNewRightSph.Value, tbNewRightCyl.Value, tbNewRightAx.Value, tbNewRightAdd.Value, tbNewRightVa.Value, tbNewRightFh.Value, tbNewRightPd2.Value, tbNewRightPd.Value,
                        tbNewDistance.IsChecked, tbNewNeutral.IsChecked, tbNewReading.IsChecked, App.User, _customer);
                }
                else
                {
                    viewModel.CreatePrescription(eyewear, tbNote.Text.Trim(), tbReExam.Value, tbPayment.Value,
                        tbNewLeftSph.Value, tbNewLeftCyl.Value, tbNewLeftAx.Value, tbNewLeftAdd.Value, tbNewLeftVa.Value, tbNewLeftFh.Value, tbNewLeftPd2.Value, tbNewLeftPd.Value,
                        tbNewRightSph.Value, tbNewRightCyl.Value, tbNewRightAx.Value, tbNewRightAdd.Value, tbNewRightVa.Value, tbNewRightFh.Value, tbNewRightPd2.Value, tbNewRightPd.Value,
                        tbNewDistance.IsChecked, tbNewNeutral.IsChecked, tbNewReading.IsChecked, App.User, _customer);
                }
            }
        }

        public void CreatePrescriptionSuccess(Prescription prescription)
        {
            ev.Post(EventEnum.NEW_PRES_SUCCESS, prescription);
        }

        public void CreatePrescriptionFailure(string message)
        {
            MessageBox.Show(message, Resource("failure") as string, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
