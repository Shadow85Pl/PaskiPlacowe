using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe.Events
{
    internal class PDFLoadEvent : PubSubEvent<PDFLoadD>
    {
    }
    internal class PDFLoadD
    {
        public byte[] PDFData { get; set; }
    }
}
