using Prism.Events;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using PaskiPlacowe.Events;
using PaskiPlacowe.ViewModel;

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

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            (DataContext as SalarySlipVM).InsertUpdateSalarySlipPoz((PaskiPlacowe.Utils.SalarySlipPozLJ)e.Row.Item, (e.EditingElement as TextBox).Text);
        }
    }
}