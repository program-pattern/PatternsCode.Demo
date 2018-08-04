using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

namespace CefSharpDemo.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();

            Application.Run(new Form1());
        }
    }
}
