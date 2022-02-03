using Manager4.core;
using Manager4.data.model;
using System.Collections.Generic;

namespace Manager4.ui.manager.statistic
{
    public interface IStatistic : INavigation
    {
        void StatisticPrescriptionSuccess(List<StaPrescription> list);
        void StatisticPrescriptionFailure(string message);
    }
}
