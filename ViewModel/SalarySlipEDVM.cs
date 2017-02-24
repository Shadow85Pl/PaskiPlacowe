using PaskiPlacowe.BaseClasses;
using PaskiPlacowe.InteractionRequest;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PaskiPlacowe.Model;
using System.IO;

namespace PaskiPlacowe.ViewModel
{
    public class SalarySlipEDVM : BaseViewModelClass, IInteractionRequestAware
    {
        private Confirmation _notification;
        private string _ChoosenFile;
        private string _SalarySlipName;
        public DelegateCommand AddSalarySlipCommand { get; private set; }
        public DelegateCommand ChooseFileCommand { get; private set; }
        public InteractionRequest<OpenFileDialogConfirmation> OpenFileRequest { get; private set; }
        public InteractionRequest<INotification> NotificationInteraction { get; private set; }

        public INotification Notification
        {
            get { return _notification; }
            set
            {
                SetProperty(ref _notification, value as Confirmation );
            }
        }

        public Action FinishInteraction
        {
            get;set;
        }
        public string ChoosenFile
        {
            get { return _ChoosenFile; }
            set
            {
                SetProperty(ref _ChoosenFile, value as String);
            }
        }

        public SalarySlipEDVM() : base(null)
        {
            this.AddSalarySlipCommand = new DelegateCommand(this.RaiseAddSalarySlip);
            ChooseFileCommand = new DelegateCommand(RaiseChooseFile);
            OpenFileRequest = new InteractionRequest<OpenFileDialogConfirmation>();
            NotificationInteraction = new InteractionRequest<INotification>();
            SalarySlipName = String.Format(Localization.Strings.SALARY_SLIP_NAME_PATTERN, DateTime.Now);
        }
        public string SalarySlipName
        {
            get { return _SalarySlipName; }
            set
            {
                SetProperty(ref _SalarySlipName, value as String);
            }
        }

        private void RaiseChooseFile()
        {
            OpenFileRequest.Raise(new OpenFileDialogConfirmation()
            {
                Filter="PDF|*.pdf"
            }, FileChoosen);
        }

        private void FileChoosen(OpenFileDialogConfirmation ChFile)
        {
            ChoosenFile = ChFile.FileName;
        }

        private void RaiseAddSalarySlip()
        {
            if(CheckFormCorrect()) {
                AddNewSalarySlip();
                if (_notification != null)
                    _notification.Confirmed = true;
                FinishInteraction();
            }
        }

        private void AddNewSalarySlip()
        {
            DB.PaskiPlacowe.Add(new PaskiPlacowe.Model.PaskiPlacowe()
            {
                ID_UZYTKOWNIKA = LoginData.GetInstance().UserId,
                NAZWA = SalarySlipName,
                PLIK = File.ReadAllBytes(ChoosenFile)
            });
            DB.SaveChanges();
        }

        private bool CheckFormCorrect()
        {
            try
            {
                if(String.IsNullOrWhiteSpace(_SalarySlipName))
                    throw new Exception(Localization.Messages.MSG_NAME_NOT_CHOOSEN);
                if (String.IsNullOrWhiteSpace(ChoosenFile))
                    throw new Exception(Localization.Messages.MSG_FILE_NOT_CHOOSEN);
                return true;
            } catch(Exception Ex)
            {
                NotificationInteraction.Raise(new Notification() {
                    Title= Localization.Strings.SALARY_SLIP_ADD_EXC_TITLE,
                    Content= Ex.Message
                });
                return false;
            }
        }
    }
}
