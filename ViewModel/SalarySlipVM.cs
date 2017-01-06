using PaskiPlacowe.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using System.Collections.ObjectModel;
using Prism.Commands;
//using Microsoft.Practices.Prism.Interactivity.

namespace PaskiPlacowe.ViewModel
{
    internal class SalarySlipVM : BaseViewModelClass
    {
        private Confirmation tmp;
        public InteractionRequest<IConfirmation> SalarySlipED { get; private set; }
        public DelegateCommand SalarySlipEAddCommand { get; private set; }
        

        public SalarySlipVM(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.SalarySlipED = new InteractionRequest<IConfirmation>();
            this.SalarySlipEAddCommand = new DelegateCommand(this.RaiseSalarySlipAdd);
            
        }
        
        private void RaiseSalarySlipAdd()
        {
            tmp=new Confirmation() { Title = Localization.Strings.SALARY_SLIP_ADD_TITLE };
            SalarySlipED.Raise(tmp,
                a => { if(a.Confirmed) AddSalarySlip(a); }
                );
        }
        private void AddSalarySlip(IConfirmation Data)
        {
            object tmp = Data.Content;
        }
        public ObservableCollection<Model.PaskiPlacowe> SalarySlipList
        {
            get
            {
                return new ObservableCollection<Model.PaskiPlacowe>(DB.PaskiPlacowe);
            }
        }
    }
}
