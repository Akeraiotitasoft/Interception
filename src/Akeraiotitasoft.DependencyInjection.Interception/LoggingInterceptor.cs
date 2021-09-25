using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Interception
{
    /// <summary>
    /// Aspect Oriented Programming.<br />
    /// Makes it so that not all methods need an exception handler just to log exceptions.<br />
    /// The interceptor does it for you.<br />
    /// </summary>
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "logger cannot be null");
        }

        /// <summary>
        /// The interceptor is called around all interface methods and virtual methods
        /// </summary>
        /// <param name="invocation">The invocation object for interception</param>
        public void Intercept(IInvocation invocation)
        {
            _logger.LogInformation($"About to call {invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name}");
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name}");
            }
            finally
            {
                _logger.LogInformation($"Finished calling {invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name}");
            }
        }
    }
}
