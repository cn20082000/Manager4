using Manager4.core;
using Manager4.util.enu;
using System;

namespace Manager4.ui.manager.statistic
{
    public class StatisticsViewModel : BaseViewModel<IStatistic>
    {
        public void StatisticPrescription(DateTime? fr, DateTime? to, StatisticEnum type)
        {
            if (fr == null || to == null)
            {
                Navigation.StatisticPrescriptionFailure(Resource("time_empty") as string);
                return;
            }
            DateTime fr1 = (DateTime)fr;
            DateTime to1 = (DateTime)to;
            if (fr1 >= to1)
            {
                Navigation.StatisticPrescriptionFailure(Resource("start_time_bigger") as string);
                return;
            }

            dataManager.StatisticPrescription(type, fr1, to1)
                .WhenSuccess(data => Navigation.StatisticPrescriptionSuccess(data))
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }
    }
}
