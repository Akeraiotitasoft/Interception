using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Interception
{
    /// <summary>
    /// The data class of the Timer interceptor
    /// </summary>
    public class TimerLog
    {
        /// <summary>
        /// The type of the class being invoked
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The method being invoked
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// The time that the method call will begin
        /// </summary>
        public DateTime Begin { get; set; }

        /// <summary>
        /// The time after the method call completed
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// The exception if one was thrown
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// The arguments to the method
        /// </summary>
        public object[] Arguments { get; set; }

        /// <summary>
        /// The return value of the method call
        /// </summary>
        public object ReturnValue { get; set; }
    }
}
