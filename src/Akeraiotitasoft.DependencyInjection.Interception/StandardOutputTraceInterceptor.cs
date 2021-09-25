using Akeraiotitasoft.IOFacade;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Interception
{
    /// <summary>
    /// For testing
    /// </summary>
    public class StandardOutputTraceInterceptor : IInterceptor
    {
        private readonly IStandardOutput _standardOutput;
        private readonly IStandardError _standardError;

        public StandardOutputTraceInterceptor(IStandardOutput standardOutput, IStandardError standardError)
        {
            _standardOutput = standardOutput ?? throw new ArgumentNullException(nameof(standardOutput), "standardOutput cannot be null");
            _standardError = standardError ?? throw new ArgumentNullException(nameof(standardError), "standardError cannot be null");
        }

        /// <summary>
        /// To make it easier to see when a method is called and if it has exceptions while testing
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            _standardOutput.WriteLine($"About to call {invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name}");
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                _standardError.WriteLine($"Error in {invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name} - it is {ex}");
            }
            finally
            {
                _standardOutput.WriteLine($"Finished calling {invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name}");
            }
        }
    }
}
