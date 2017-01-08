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
using PaskiPlacowe.Model;
using System.IO;
using PaskiPlacowe.Events;

namespace PaskiPlacowe.ViewModel
{
    internal class SalarySlipVM : BaseViewModelClass
    {
        private Confirmation tmp;
        private PaskiPlacowe.Model.PaskiPlacowe _SelectedSalarySlip;
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
            if (Data.Confirmed)
                OnPropertyChanged("SalarySlipList");
        }
        public ObservableCollection<Model.PaskiPlacowe> SalarySlipList
        {
            get
            {
                long LogedInUserID = LoginData.GetInstance().UserId;
                return new ObservableCollection<Model.PaskiPlacowe>(DB.PaskiPlacowe.Where(a=>a.ID_UZYTKOWNIKA== LogedInUserID));
            }
        }
        public PaskiPlacowe.Model.PaskiPlacowe SelectedSalarySlip
        {
            get { return _SelectedSalarySlip; }
            set
            {
                SetProperty(ref _SelectedSalarySlip, value as PaskiPlacowe.Model.PaskiPlacowe);
                eventAggregator.GetEvent<PDFLoadEvent>().Publish(new PDFLoadD() { PDFData= (value as PaskiPlacowe.Model.PaskiPlacowe)?.PLIK });
            }
        }
    }
}
