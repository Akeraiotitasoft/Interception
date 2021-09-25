using Akeraiotitasoft.Linq.Statistics;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Interception
{
    /// <summary>
    /// This is the Aspect Oriented Programming interceptor to calculate method timings.
    /// </summary>
    public class TimerInterceptor : IInterceptor, IDisposable
    {
        private List<TimerLog> TimerLogs { get; set; } = new List<TimerLog>();

        private readonly ILogger<TimerInterceptor> _logger;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        public TimerInterceptor(ILogger<TimerInterceptor> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "logger cannot be null");
        }

        /// <summary>
        /// The interceptor to call a method between time snapshots.
        /// </summary>
        /// <param name="invocation">The interceptor invocation object</param>
        public void Intercept(IInvocation invocation)
        {
            TimerLog timerLog = new TimerLog();
            timerLog.Type = invocation.TargetType;
            timerLog.Method = invocation.MethodInvocationTarget;
            timerLog.Arguments = invocation.Arguments;
            timerLog.Begin = DateTime.UtcNow;
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                timerLog.Exception = ex;
            }
            finally
            {
                timerLog.End = DateTime.UtcNow;
                timerLog.ReturnValue = invocation.ReturnValue;
                TimerLogs.Add(timerLog);
            }
        }

        /// <summary>
        /// Calculates the statistics of the method calls when disposed.
        /// </summary>
        public void Dispose()
        {
            var timeReports = TimerLogs.GroupBy(timerLog => new { timerLog.Type, timerLog.Method })
                .Select(timerLog => new
                {
                    Type = timerLog.Key.Type,
                    Method = timerLog.Key.Method,
                    AverageTime = timerLog.Average(x => (x.End - x.Begin).TotalMilliseconds),
                    MaxTime = timerLog.Max(x => (x.End - x.Begin).TotalMilliseconds),
                    MinTime = timerLog.Min(x => (x.End - x.Begin).TotalMilliseconds),
                    Percentile25 = timerLog.InversePercentile(x => (x.End - x.Begin).TotalMilliseconds, 0.25),
                    Percentile50 = timerLog.InversePercentile(x => (x.End - x.Begin).TotalMilliseconds, 0.5),
                    Percentile75 = timerLog.InversePercentile(x => (x.End - x.Begin).TotalMilliseconds, 0.75),
                    Percentile90 = timerLog.InversePercentile(x => (x.End - x.Begin).TotalMilliseconds, 0.9),
                    StdDev = timerLog.StandardDeviation(x => (x.End - x.Begin).TotalMilliseconds)
                });

            foreach (var timeReport in timeReports)
            {
                _logger.LogInformation($"Type {timeReport.Type.Name}, Method {timeReport.Method.Name}, Average Time {timeReport.AverageTime}, Max Time {timeReport.MaxTime}, Min Time {timeReport.MinTime}");
                _logger.LogInformation($"25 Percentile {timeReport.Percentile25}, 50 Percentile {timeReport.Percentile50}, 75 Percentile {timeReport.Percentile75}, 90 Percentile {timeReport.Percentile90}");
                _logger.LogInformation($"StdDev = {timeReport.StdDev}");
            }
        }
    }
}
