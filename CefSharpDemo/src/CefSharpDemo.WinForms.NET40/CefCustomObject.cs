using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;

namespace CefSharpDemo.WinForms
{
    class CefCustomObject
    {
        // Declare a local instance of chromium and the main form in order to execute things from here in the main thread
        private static ChromiumWebBrowser _instanceBrowser = null;
        // The form class needs to be changed according to yours
        private static Form _instanceMainForm = null;

        public CefCustomObject(ChromiumWebBrowser originalBrowser, Form mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;
        }

        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        public void showDialog(string text)
        {
            MessageBox.Show(text);
        }
    }
}
