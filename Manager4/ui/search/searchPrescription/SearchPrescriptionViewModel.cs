using Manager4.core;
using System;

namespace Manager4.ui.search.searchPrescription
{
    public class SearchPrescriptionViewModel : BaseViewModel<ISearchPrescription>
    {
        public void FindPrescription(string key)
        {
            dataManager.FindPrescriptionByKey(key)
                .WhenSuccess(data => Navigation.FindPrescriptionSuccess(data))
                .WhenFailure(error => Console.WriteLine(error))
                .Call();
        }
    }
}
