using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Topshelf;
using Topshelf.LibLog;

namespace PatternsCode.WindowsServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseLibLog();
                x.Service<ServiceRunner>();
                x.RunAsLocalSystem();
                x.SetDescription("A Windows Service Demo using TopShelf and Quartz");
                x.SetDisplayName("WindowsServiceDemo");
                x.SetServiceName("WindowsServiceDemoService");
                x.EnablePauseAndContinue();
            });
        }
    }
}
