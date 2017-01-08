using Patagames.Pdf.Net;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PaskiPlacowe.Events;

namespace PaskiPlacowe.View
{
    /// <summary>
    /// Interaction logic for SalarySlipDetailV.xaml
    /// </summary>
    public partial class SalarySlipDetailV : UserControl
    {
        public SalarySlipDetailV()
        {
            InitializeComponent();
            IEventAggregator eventAggregator = AppService.Instance.EventAggregator;
            eventAggregator.GetEvent<PDFLoadEvent>().Subscribe(OnPDFLoadEvent);
        }

        private void OnPDFLoadEvent(PDFLoadD obj)
        {
            MemoryStream MS = new MemoryStream(obj.PDFData);
            MS.Position = 0;
            SalarySlipViewer.Load(MS);
            SalarySlipViewer.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitWidth;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SalarySlipViewer.LoadingIndicator.LoadingMessage = Localization.Strings.LOADING_PDF_DOCUMENT;
            SalarySlipViewer.EnableNotificationBar = false;
        }
    }
}
