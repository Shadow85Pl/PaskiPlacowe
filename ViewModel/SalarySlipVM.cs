using PaskiPlacowe.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace PaskiPlacowe.ViewModel
{
    internal class SalarySlipVM : BaseViewModelClass
    {
        public SalarySlipVM(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}
