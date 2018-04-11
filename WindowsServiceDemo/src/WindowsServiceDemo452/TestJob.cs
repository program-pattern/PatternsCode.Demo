using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using NLog;
using System.Threading.Tasks;

namespace PatternsCode.WindowsServiceDemo
{
    public sealed class TestJob : IJob
    {
        Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                _logger.Debug("Test Job");
            });
        }
    }
}
