using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Interception
{
    /// <summary>
    /// ServiceCollection extensions for Aspect Oriented Programming.  (That is Interception.)  This is also called AOP.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all registered interceptors to the interface registration as Scoped
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <typeparam name="TImplementation">The implementation</typeparam>
        /// <param name="services">The service collection</param>
        public static void AddProxiedScoped<TInterface, TImplementation>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "services cannot be null");
            }
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<IProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }

        /// <summary>
        /// Adds the specified registered interceptors to the interface registration as Scoped
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <typeparam name="TImplementation">The implementation</typeparam>
        /// <typeparam name="TInterceptor">This can be a single interceptor class or multiple in a TypeList generic</typeparam>
        /// <param name="services">The service collection</param>
        public static void AddProxiedScoped<TInterface, TImplementation, TInterceptor>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "services cannot be null");
            }
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<IProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetFilteredServices<IInterceptor, TInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }

        /// <summary>
        /// Adds all registered interceptors to the interface registration as a Transient
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <typeparam name="TImplementation">The implementation</typeparam>
        /// <param name="services">The service collection</param>
        public static void AddProxiedTransient<TInterface, TImplementation>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "services cannot be null");
            }
            services.AddTransient<TImplementation>();
            services.AddTransient(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<IProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }

        /// <summary>
        /// Adds the specified registered interceptors to the interface registration as a Transient
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <typeparam name="TImplementation">The implementation</typeparam>
        /// <typeparam name="TInterceptor">This can be a single interceptor class or multiple in a TypeList generic</typeparam>
        /// <param name="services">The service collection</param>
        public static void AddProxiedTransient<TInterface, TImplementation, TInterceptor>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "services cannot be null");
            }
            services.AddTransient<TImplementation>();
            services.AddTransient(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<IProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetFilteredServices<IInterceptor, TInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }

        /// <summary>
        /// Adds all registered interceptors to the interface registration as a Singleton
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <typeparam name="TImplementation">The implementation</typeparam>
        /// <param name="services">The service collection</param>
        public static void AddProxiedSingleton<TInterface, TImplementation>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "services cannot be null");
            }
            services.AddSingleton<TImplementation>();
            services.AddSingleton(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<IProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }

        /// <summary>
        /// Adds the specified registered interceptors to the interface registration as a Transient
        /// </summary>
        /// <typeparam name="TInterface">The interface</typeparam>
        /// <typeparam name="TImplementation">The implementation</typeparam>
        /// <typeparam name="TInterceptor">This can be a single interceptor class or multiple in a TypeList generic</typeparam>
        /// <param name="services">The service collection</param>
        public static void AddProxiedSingleton<TInterface, TImplementation, TInterceptor>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "services cannot be null");
            }
            services.AddSingleton<TImplementation>();
            services.AddSingleton(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<IProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetFilteredServices<IInterceptor, TInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }

        // this is the trick to make the TypeList work
        private static IEnumerable<TReturn> GetFilteredServices<TReturn, TFilter>(this IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider), "serviceProvider cannot be null");
            }
            IEnumerable<TReturn> services;
            if (typeof(TFilter).IsAssignableTo(typeof(TypeList)))
            {
                Type[] types = TypeList.ToTypes(typeof(TFilter));
                services = serviceProvider.GetServices<TReturn>().Where(x => types.Contains(x.GetType())).ToArray();
            }
            else
            {
                services = serviceProvider.GetServices<TReturn>().Where(x => x.GetType() == typeof(TFilter)).ToArray();
            }
            return services;
        }
    }
}
