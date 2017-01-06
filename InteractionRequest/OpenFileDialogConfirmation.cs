using Prism.Interactivity.InteractionRequest;

namespace PaskiPlacowe.InteractionRequest
{

    public class OpenFileDialogConfirmation : Confirmation
    {
        public System.Boolean? Multiselect { get; set; }
        public System.Boolean? ReadOnlyChecked { get; set; }
        public System.Boolean? ShowReadOnly { get; set; }
        public System.Boolean? AddExtension { get; set; }
        public System.Boolean? CheckFileExists { get; set; }
        public System.Boolean? CheckPathExists { get; set; }
        public System.String DefaultExt { get; set; }
        public System.Boolean? DereferenceLinks { get; set; }
        public System.String SafeFileName { get; set; }
        public System.String[] SafeFileNames { get; set; }
        public System.String FileName { get; set; }
        public System.String[] FileNames { get; set; }
        public System.String Filter { get; set; }
        public System.Int32? FilterIndex { get; set; }
        public System.String InitialDirectory { get; set; }
        public System.Boolean? RestoreDirectory { get; set; }
        public System.Boolean? ValidateNames { get; set; }
        public System.Collections.Generic.IList<Microsoft.Win32.FileDialogCustomPlace> CustomPlaces { get; set; }
        public System.Object Tag { get; set; }
    }
}
