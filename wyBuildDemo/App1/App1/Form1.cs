using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace App1
{
    public partial class Form1 : Form, IMessageFilter
    {
        private const int MAXIDLETICKS = 20;
        private volatile int _updateCode = -1;
        private bool _updateAlert = false;
        private Timer _timer;
        private int _idleTicks = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //更新检测
            try
            {
                string pathtofile = "wyUpdate.exe";
                Process process = new Process();
                process.StartInfo.FileName = pathtofile;
                process.StartInfo.Arguments = @" /quickcheck /justcheck /noerr";
                process.EnableRaisingEvents = true;
                process.Exited += process_Exited;
                process.Start();
            }
            catch (Exception ex1)
            {

            }

            //空闲检测
            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 1000;
            _timer.Start();

            Application.AddMessageFilter(this);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (++_idleTicks >= MAXIDLETICKS)
            {
                if (this._updateCode == 2 && !this._updateAlert)
                {
                    if (this.UpdateApplication())
                    {
                        this.DialogResult = DialogResult.Abort;
                    }
                }
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (isUserInput(m))
            {
                _idleTicks = 0;
            }

            return false;
        }

        private bool isUserInput(Message m)
        {
            // look for any message that was the result of user input
            if (m.Msg == 0x200) { return true; } // WM_MOUSEMOVE
            if (m.Msg == 0x020A) { return true; } // WM_MOUSEWHEEL
            if (m.Msg == 0x100) { return true; } // WM_KEYDOWN
            if (m.Msg == 0x101) { return true; } // WM_KEYUP

            // ... etc

            return false;
        }

        void process_Exited(object sender, EventArgs e)
        {
            Process p = (Process)sender;
            int exitCode = p.ExitCode;
            this._updateCode = exitCode; //0没有更新,1检测错误,2发现更新
        }

        private bool UpdateApplication()
        {
            bool ret = false;

            this._updateAlert = true;

            if (DialogResult.Yes == MessageBox.Show("程序已经发现新版本，现在是否立即退出程序以进行更新？", "SCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                ret = true;
                try
                {
                    string pathtofile = @"wyUpdate.exe";
                    Process process = new Process();
                    process.StartInfo.FileName = pathtofile;
                    process.Start();
                }
                catch (Exception)
                {

                }
            }
            return ret;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }
    }
}
