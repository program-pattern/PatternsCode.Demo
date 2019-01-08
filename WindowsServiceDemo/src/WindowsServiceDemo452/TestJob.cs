using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using PatternsCode.WindowsServiceDemo.Logging;
using System.Threading.Tasks;

namespace PatternsCode.WindowsServiceDemo
{
    public sealed class TestJob : IJob
    {
        ILog _logger = LogProvider.GetCurrentClassLogger();

        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                _logger.Debug("Test Job");
            });
        }
    }
}
