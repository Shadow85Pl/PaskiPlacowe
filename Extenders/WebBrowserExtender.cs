using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PaskiPlacowe.Extenders
{
    public class WebBrowserExtender
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(WebBrowserExtender),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        public static readonly DependencyProperty LoadStreamProperty = DependencyProperty.RegisterAttached(
            "LoadStream",
            typeof(Stream),
            typeof(WebBrowserExtender),
            new FrameworkPropertyMetadata(OnStreamChanged));

        private static void OnStreamChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                //webBrowser.DocumentStream = e.NewValue as Stream ?? null;

                webBrowser.NavigateToStream(e.NewValue as Stream ?? null);
            }
        }

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtml(WebBrowser d)
        {
            return (string)d.GetValue(HtmlProperty);
        }

        public static void SetHtml(WebBrowser d, string value)
        {
            d.SetValue(HtmlProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static Stream GetLoadStream(WebBrowser d)
        {
            return (Stream)d.GetValue(LoadStreamProperty);
        }

        public static void SetLoadStream(WebBrowser d, Stream value)
        {
            d.SetValue(LoadStreamProperty, value);
        }

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string ?? "&nbsp;");
            }
        }
    }
}