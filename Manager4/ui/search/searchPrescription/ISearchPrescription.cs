using Manager4.core;
using Manager4.data.model;
using System.Collections.Generic;

namespace Manager4.ui.search.searchPrescription
{
    public interface ISearchPrescription : INavigation
    {
        void FindPrescriptionSuccess(List<Prescription> list);
    }
}
