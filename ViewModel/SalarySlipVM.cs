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
using System.Data.Entity;
using PaskiPlacowe.Utils;

namespace PaskiPlacowe.ViewModel
{
    internal class SalarySlipVM : BaseViewModelClass
    {
        private Confirmation tmp;
        private PaskiPlacowe.Model.PaskiPlacowe _SelectedSalarySlip;
        public InteractionRequest<IConfirmation> SalarySlipED { get; private set; }
        public DelegateCommand SalarySlipEAddCommand { get; private set; }
        public DelegateCommand Logout { get; private set; }
        public DelegateCommand DeleteSalarySlip { get; private set; }


        public SalarySlipVM(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.SalarySlipED = new InteractionRequest<IConfirmation>();
            this.SalarySlipEAddCommand = new DelegateCommand(this.RaiseSalarySlipAdd);
            this.Logout = new DelegateCommand(this.RaiseLogout);
            this.DeleteSalarySlip = new DelegateCommand(this.RaiseDeleteSalarySlip);
        }

        private void RaiseDeleteSalarySlip()
        {
            //TODO:Delete salary slip event
        }

        private void RaiseLogout()
        {
            //TODO:Logout event
        }

        private void RaiseSalarySlipAdd()
        {
            SalarySlipED.Raise(new Confirmation() { Title = Localization.Strings.SALARY_SLIP_ADD_TITLE },
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
                var data = DB.PaskiPlacowe.Where(a => a.ID_UZYTKOWNIKA == LogedInUserID).Include("PaskiPlacowe_POZ.SL_TYPOW_POL_PP");
                if (data.Count() > 0)
                {
                    return new ObservableCollection<Model.PaskiPlacowe>(data);
                }
                else return null;
            }
        }
        public PaskiPlacowe.Model.PaskiPlacowe SelectedSalarySlip
        {
            get { return _SelectedSalarySlip; }
            set
            {
                SetProperty(ref _SelectedSalarySlip, value as PaskiPlacowe.Model.PaskiPlacowe);
                eventAggregator.GetEvent<PDFLoadEvent>().Publish(new PDFLoadD() { PDFData= (value as PaskiPlacowe.Model.PaskiPlacowe)?.PLIK });
                OnPropertyChanged("SelectedSalarySlipPoz");
            }
        }
        public void InsertUpdateSalarySlipPoz(PaskiPlacowe.Utils.SalarySlipPozLJ Poz, string NewValue)
        {
            if (Poz.POZ != null && DB.PaskiPlacowe_POZ.Where(a => a.ID_PASEK_PLACOWY_POZ == Poz.POZ.ID_PASEK_PLACOWY_POZ).Any())
            {
                PaskiPlacowe_POZ PaskiPoz= DB.PaskiPlacowe_POZ.Where(a => a.ID_PASEK_PLACOWY_POZ == Poz.POZ.ID_PASEK_PLACOWY_POZ).SingleOrDefault();
                PaskiPoz.WARTOSC = NewValue;
            }
            else
            {
                PaskiPlacowe_POZ NewPoz= AutoMapper.Mapper.Map<PaskiPlacowe_POZ>(Poz);
                NewPoz.ID_PASKA = SelectedSalarySlip.ID_PASKA;
                NewPoz.WARTOSC = NewValue;
                DB.PaskiPlacowe_POZ.Add(NewPoz);
            }
            DB.SaveChanges();
            OnPropertyChanged("SelectedSalarySlipPoz");
        }
        public List<PaskiPlacowe.Utils.SalarySlipPozLJ> SelectedSalarySlipPoz
        {
            get
            {
                return SelectedSalarySlip != null ? (from SPoz in DB.SL_TYPOW_POL_PP
                                                       join POZ in DB.PaskiPlacowe_POZ.Where(a=>a.ID_PASKA == SelectedSalarySlip.ID_PASKA) on SPoz equals POZ.SL_TYPOW_POL_PP into PozEQ
                                                       from P in PozEQ.DefaultIfEmpty()
                                                       select new PaskiPlacowe.Utils.SalarySlipPozLJ()
                                                       {
                                                           SPOZ = SPoz,
                                                           POZ = P?? default(PaskiPlacowe_POZ)
                                                       }).ToList() : null;
            }
                         
        }
    }
}
