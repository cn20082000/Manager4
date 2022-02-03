using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.ext;
using System.Windows;
using System.Windows.Controls;

namespace Manager4.ui.prescription.preview
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : PreviewView, IPreview
    {
        private Prescription _pres;

        public PreviewWindow(Prescription pres)
        {
            _pres = pres;
            InitializeComponent();
            Setup();
        }

        protected override void InitUI()
        {
            Title = Resource("preview") + " - " + Resource("prescription") + " M" + _pres.Key;
            tblContact1.Text = App.setting.Contact1;
            tblContact2.Text = App.setting.Contact2;
            tblName.Text = _pres.Customer.Name;
            tblBirthday.Text = _pres.Customer.Birthday.ToString("dd/MM/yyyy");
            tblAddress.Text = _pres.Customer.Address;
            tblPhoneNumber.Text = _pres.Customer.PhoneNumber;
            tblKey.Text = "M" + _pres.Key;

            if (_pres.OldReport != null)
            {
                tblOldLeftSph.Text = _pres.OldReport.LeftEye.Sph.ToPrint();
                tblOldLeftCyl.Text = _pres.OldReport.LeftEye.Cyl.ToPrint();
                tblOldLeftAx.Text = _pres.OldReport.LeftEye.Cyl == 0 ? "" : _pres.OldReport.LeftEye.Ax.ToString();
                tblOldLeftAdd.Text = _pres.OldReport.LeftEye.Add.ToPrint();
                tblOldLeftVa.Text = _pres.OldReport.LeftEye.Va + "/10";
                tblOldLeftFh.Text = _pres.OldReport.LeftEye.Fh == 0 ? "" : string.Format("{0:0.0}", _pres.OldReport.LeftEye.Fh);
                tblOldLeftPd2.Text = string.Format("{0:0.0}", _pres.OldReport.LeftEye.Pd2);
                tblOldLeftPd.Text = string.Format("{0:0.0}", _pres.OldReport.LeftEye.Pd); tblOldLeftSph.Text = _pres.OldReport.LeftEye.Sph.ToPrint();

                tblOldRightCyl.Text = _pres.OldReport.RightEye.Cyl.ToPrint();
                tblOldRightAx.Text = _pres.OldReport.RightEye.Cyl == 0 ? "" : _pres.OldReport.RightEye.Ax.ToString();
                tblOldRightAdd.Text = _pres.OldReport.RightEye.Add.ToPrint();
                tblOldRightVa.Text = _pres.OldReport.RightEye.Va + "/10";
                tblOldRightFh.Text = _pres.OldReport.RightEye.Fh == 0 ? "" : string.Format("{0:0.0}", _pres.OldReport.RightEye.Fh);
                tblOldRightPd2.Text = string.Format("{0:0.0}", _pres.OldReport.RightEye.Pd2);
                tblOldRightPd.Text = string.Format("{0:0.0}", _pres.OldReport.RightEye.Pd);

                tblOldDistance.Text = _pres.OldReport.Distance ? "X" : "";
                tblOldNeutral.Text = _pres.OldReport.Neutral ? "X" : "";
                tblOldReading.Text = _pres.OldReport.Reading ? "X" : "";
            }
            else
            {
                tblOldLeftSph.Text = "";
                tblOldLeftCyl.Text = "";
                tblOldLeftAx.Text = "";
                tblOldLeftAdd.Text = "";
                tblOldLeftVa.Text = "";
                tblOldLeftFh.Text = "";
                tblOldLeftPd2.Text = "";
                tblOldLeftPd.Text = "";

                tblOldRightSph.Text = "";
                tblOldRightCyl.Text = "";
                tblOldRightAx.Text = "";
                tblOldRightAdd.Text = "";
                tblOldRightVa.Text = "";
                tblOldRightFh.Text = "";
                tblOldRightPd2.Text = "";
                tblOldRightPd.Text = "";

                tblOldDistance.Text = "";
                tblOldNeutral.Text = "";
                tblOldReading.Text = "";
            }

            tblNewLeftSph.Text = _pres.NewReport.LeftEye.Sph.ToPrint();
            tblNewLeftCyl.Text = _pres.NewReport.LeftEye.Cyl.ToPrint();
            tblNewLeftAx.Text = _pres.NewReport.LeftEye.Cyl == 0 ? "" : _pres.NewReport.LeftEye.Ax.ToString();
            tblNewLeftAdd.Text = _pres.NewReport.LeftEye.Add.ToPrint();
            tblNewLeftVa.Text = _pres.NewReport.LeftEye.Va + "/10";
            tblNewLeftFh.Text = _pres.NewReport.LeftEye.Fh == 0 ? "" : string.Format("{0:0.0}", _pres.NewReport.LeftEye.Fh);
            tblNewLeftPd2.Text = string.Format("{0:0.0}", _pres.NewReport.LeftEye.Pd2);
            tblNewLeftPd.Text = string.Format("{0:0.0}", _pres.NewReport.LeftEye.Pd); tblNewLeftSph.Text = _pres.NewReport.LeftEye.Sph.ToPrint();

            tblNewRightCyl.Text = _pres.NewReport.RightEye.Cyl.ToPrint();
            tblNewRightAx.Text = _pres.NewReport.RightEye.Cyl == 0 ? "" : _pres.NewReport.RightEye.Ax.ToString();
            tblNewRightAdd.Text = _pres.NewReport.RightEye.Add.ToPrint();
            tblNewRightVa.Text = _pres.NewReport.RightEye.Va + "/10";
            tblNewRightFh.Text = _pres.NewReport.RightEye.Fh == 0 ? "" : string.Format("{0:0.0}", _pres.NewReport.RightEye.Fh);
            tblNewRightPd2.Text = string.Format("{0:0.0}", _pres.NewReport.RightEye.Pd2);
            tblNewRightPd.Text = string.Format("{0:0.0}", _pres.NewReport.RightEye.Pd);

            tblNewDistance.Text = _pres.NewReport.Distance ? "X" : "";
            tblNewNeutral.Text = _pres.NewReport.Neutral ? "X" : "";
            tblNewReading.Text = _pres.NewReport.Reading ? "X" : "";

            switch (_pres.Eyewear)
            {
                case EyewearEnum.SINGLE:
                    {
                        tblSingle.Text = "X";
                        break;
                    }
                case EyewearEnum.BIOFOCAL:
                    {
                        tblBiofocal.Text = "X";
                        break;
                    }
                case EyewearEnum.PROGRESSIVE:
                    {
                        tblProgressive.Text = "X";
                        break;
                    }
                case EyewearEnum.EYEWEAR_SET:
                    {
                        tblEyewearSet.Text = "X";
                        break;
                    }
            }

            tblNote.Text = _pres.Note;
            tblReExam.Text = _pres.ReExam.ToString();
            tblDay.Text = _pres.Time.ToString("dd");
            tblMonth.Text = _pres.Time.ToString("MM");
            tblYear.Text = _pres.Time.ToString("yyyy");
            tblSignature.Text = _pres.User.Signature;
        }

        protected override IPreview Navigation() => this;

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(grPrint, Resource("prescription") + "M" + _pres.Key);
        }
    }
}
