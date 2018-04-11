using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Quartz.Impl;
using Topshelf;
using System.Threading.Tasks;

namespace PatternsCode.WindowsServiceDemo
{
    public class ServiceRunner : ServiceControl, ServiceSuspend
    {
        private readonly IScheduler scheduler;

        public ServiceRunner()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start().Wait();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown(false).Wait();
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll().Wait();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll().Wait();
            return true;
        }

    }
}
