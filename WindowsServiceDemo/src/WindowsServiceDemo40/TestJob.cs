using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using NLog;

namespace PatternsCode.WindowsServiceDemo
{
    public sealed class TestJob : IJob
    {
        Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        {
            _logger.Info("Test Job");
        }
    }
}
