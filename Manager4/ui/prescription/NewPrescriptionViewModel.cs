using Manager4.core;
using Manager4.data.model;
using Manager4.util.enu;
using System;

namespace Manager4.ui.prescription
{
    public class NewPrescriptionViewModel : BaseViewModel<INewPrescription>
    {
        public void GetLastPrescription(Customer cus)
        {
            dataManager.GetLastPrescription(cus)
                .WhenSuccess(data => Navigation.GetLastPrescriptionSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.GetLastPrescriptionFailure("");
                })
                .Call();
        }

        public void CreatePrescription(EyewearEnum eyewear, string note, int? reExam, decimal? payment,
            decimal? newLeftSph, decimal? newLeftCyl, int? newLeftAx, decimal? newLeftAdd, int? newLeftVa, int? newLeftFh, decimal? newLeftPd2, decimal? newLeftPd,
            decimal? newRightSph, decimal? newRightCyl, int? newRightAx, decimal? newRightAdd, int? newRightVa, int? newRightFh, decimal? newRightPd2, decimal? newRightPd,
            bool? newDistance, bool? newNeutral, bool? newReading, User user, Customer customer)
        {
            if (reExam == null || payment == null || newLeftSph == null || newLeftCyl == null || newLeftAx == null || newLeftAdd == null || newLeftVa == null || newLeftFh == null || newLeftPd2 == null || newLeftPd == null
                || newRightSph == null || newRightCyl == null || newRightAx == null || newRightAdd == null || newRightVa == null || newRightFh == null || newRightPd2 == null || newRightPd == null
                || newDistance == null || newNeutral == null || newReading == null)
            {
                Navigation.CreatePrescriptionFailure(Resource("field_empty") as string);
                return;
            }
            dataManager.CreatePrescription(eyewear, note, (int)reExam, (float)payment,
                (float)newLeftSph, (float)newLeftCyl, (int)newLeftAx, (float)newLeftAdd, (int)newLeftVa, (int)newLeftFh, (float)newLeftPd2, (float)newLeftPd,
                (float)newRightSph, (float)newRightCyl, (int)newRightAx, (float)newRightAdd, (int)newRightVa, (int)newRightFh, (float)newRightPd2, (float)newRightPd,
                (bool)newDistance, (bool)newNeutral, (bool)newReading, user, customer)
                .WhenSuccess(data => Navigation.CreatePrescriptionSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.CreatePrescriptionFailure(Resource("unknown_error") as string);
                })
                .Call();
        }

        public void CreatePrescription(EyewearEnum eyewear, string note, int? reExam, decimal? payment, Report oldReport,
            decimal? newLeftSph, decimal? newLeftCyl, int? newLeftAx, decimal? newLeftAdd, int? newLeftVa, int? newLeftFh, decimal? newLeftPd2, decimal? newLeftPd,
            decimal? newRightSph, decimal? newRightCyl, int? newRightAx, decimal? newRightAdd, int? newRightVa, int? newRightFh, decimal? newRightPd2, decimal? newRightPd,
            bool? newDistance, bool? newNeutral, bool? newReading, User user, Customer customer)
        {
            if (reExam == null || payment == null || newLeftSph == null || newLeftCyl == null || newLeftAx == null || newLeftAdd == null || newLeftVa == null || newLeftFh == null || newLeftPd2 == null || newLeftPd == null
                || newRightSph == null || newRightCyl == null || newRightAx == null || newRightAdd == null || newRightVa == null || newRightFh == null || newRightPd2 == null || newRightPd == null
                || newDistance == null || newNeutral == null || newReading == null)
            {
                Navigation.CreatePrescriptionFailure(Resource("field_empty") as string);
                return;
            }
            dataManager.CreatePrescription(eyewear, note, (int)reExam, (float)payment, oldReport,
                (float)newLeftSph, (float)newLeftCyl, (int)newLeftAx, (float)newLeftAdd, (int)newLeftVa, (int)newLeftFh, (float)newLeftPd2, (float)newLeftPd,
                (float)newRightSph, (float)newRightCyl, (int)newRightAx, (float)newRightAdd, (int)newRightVa, (int)newRightFh, (float)newRightPd2, (float)newRightPd,
                (bool)newDistance, (bool)newNeutral, (bool)newReading, user, customer)
                .WhenSuccess(data => Navigation.CreatePrescriptionSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.CreatePrescriptionFailure(Resource("unknown_error") as string);
                })
                .Call();
        }

        public void CreatePrescription(EyewearEnum eyewear, string note, int? reExam, decimal? payment,
            decimal? oldLeftSph, decimal? oldLeftCyl, int? oldLeftAx, decimal? oldLeftAdd, int? oldLeftVa, int? oldLeftFh, decimal? oldLeftPd2, decimal? oldLeftPd,
            decimal? oldRightSph, decimal? oldRightCyl, int? oldRightAx, decimal? oldRightAdd, int? oldRightVa, int? oldRightFh, decimal? oldRightPd2, decimal? oldRightPd,
            bool? oldDistance, bool? oldNeutral, bool? oldReading,
            decimal? newLeftSph, decimal? newLeftCyl, int? newLeftAx, decimal? newLeftAdd, int? newLeftVa, int? newLeftFh, decimal? newLeftPd2, decimal? newLeftPd,
            decimal? newRightSph, decimal? newRightCyl, int? newRightAx, decimal? newRightAdd, int? newRightVa, int? newRightFh, decimal? newRightPd2, decimal? newRightPd,
            bool? newDistance, bool? newNeutral, bool? newReading, User user, Customer customer)
        {
            if (reExam == null || payment == null
                || oldLeftSph == null || oldLeftCyl == null || oldLeftAx == null || oldLeftAdd == null || oldLeftVa == null || oldLeftFh == null || oldLeftPd2 == null || oldLeftPd == null
                || oldRightSph == null || oldRightCyl == null || oldRightAx == null || oldRightAdd == null || oldRightVa == null || oldRightFh == null || oldRightPd2 == null || oldRightPd == null
                || oldDistance == null || oldNeutral == null || oldReading == null
                || newLeftSph == null || newLeftCyl == null || newLeftAx == null || newLeftAdd == null || newLeftVa == null || newLeftFh == null || newLeftPd2 == null || newLeftPd == null
                || newRightSph == null || newRightCyl == null || newRightAx == null || newRightAdd == null || newRightVa == null || newRightFh == null || newRightPd2 == null || newRightPd == null
                || newDistance == null || newNeutral == null || newReading == null)
            {
                Navigation.CreatePrescriptionFailure(Resource("field_empty") as string);
                return;
            }
            dataManager.CreatePrescription(eyewear, note, (int)reExam, (float)payment,
                (float)oldLeftSph, (float)oldLeftCyl, (int)oldLeftAx, (float)oldLeftAdd, (int)oldLeftVa, (int)oldLeftFh, (float)oldLeftPd2, (float)oldLeftPd,
                (float)oldRightSph, (float)oldRightCyl, (int)oldRightAx, (float)oldRightAdd, (int)oldRightVa, (int)oldRightFh, (float)oldRightPd2, (float)oldRightPd,
                (bool)oldDistance, (bool)oldNeutral, (bool)oldReading,
                (float)newLeftSph, (float)newLeftCyl, (int)newLeftAx, (float)newLeftAdd, (int)newLeftVa, (int)newLeftFh, (float)newLeftPd2, (float)newLeftPd,
                (float)newRightSph, (float)newRightCyl, (int)newRightAx, (float)newRightAdd, (int)newRightVa, (int)newRightFh, (float)newRightPd2, (float)newRightPd,
                (bool)newDistance, (bool)newNeutral, (bool)newReading, user, customer)
                .WhenSuccess(data => Navigation.CreatePrescriptionSuccess(data))
                .WhenFailure(error =>
                {
                    Console.WriteLine(error);
                    Navigation.CreatePrescriptionFailure(Resource("unknown_error") as string);
                })
                .Call();
        }
    }
}
