using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Interception
{
    /// <summary>
    /// Utility class to have a list of generic types
    /// </summary>
    public class TypeList
    {
        /// <summary>
        /// Method to get the types from the TypeList.<br />
        /// It is zero types for this class but it is overridden by child classes.<br />
        /// </summary>
        /// <returns>A array of types</returns>
        public virtual Type[] GetTypes()
        {
            return new Type[0];
        }

        /// <summary>
        /// Gets the types
        /// </summary>
        /// <typeparam name="T">A TypeList to get the types from</typeparam>
        /// <returns>An array of types</returns>
        public static Type[] ToTypes<T>()
            where T : TypeList, new()
        {
            return new T().GetTypes();
        }

        /// <summary>
        /// Gets the types
        /// </summary>
        /// <param name="type">The type of a TypeList to get the types from</param>
        /// <returns>An array of types</returns>
        public static Type[] ToTypes(Type type)
        {
            if (!type.IsAssignableTo(typeof(TypeList)))
            {
                throw new ArgumentException("type needs to inherit from TypeList", nameof(type));
            }

            var types = (TypeList)Activator.CreateInstance(type);
            return types.GetTypes();
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns a single type <typeparamref name="T1"/><br />
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public sealed class TypeList<T1> : TypeList
    {
        /// <summary>
        /// Gets a single type <typeparamref name="T1"/>
        /// </summary>
        /// <returns>An array of types with one element</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns 2 types <typeparamref name="T1"/> and <typeparamref name="T2"/>
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    public sealed class TypeList<T1, T2> : TypeList
    {
        /// <summary>
        /// Gets 2 types <typeparamref name="T1"/> and <typeparamref name="T2"/>
        /// </summary>
        /// <returns>An array of types with 2 elements</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1), typeof(T2) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns 3 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/>
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    /// <typeparam name="T3">The third type</typeparam>
    public sealed class TypeList<T1, T2, T3> : TypeList
    {
        /// <summary>
        /// Gets 3 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/>
        /// </summary>
        /// <returns>An array of types with 3 elements</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1), typeof(T2), typeof(T3) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns 4 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/><br /> and <typeparamref name="T4"/>
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    /// <typeparam name="T3">The third type</typeparam>
    /// <typeparam name="T4">The fourth type</typeparam>
    public sealed class TypeList<T1, T2, T3, T4> : TypeList
    {
        /// <summary>
        /// Gets 4 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/> and <typeparamref name="T4"/>
        /// </summary>
        /// <returns>An array of types with 4 elements</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns 5 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/><br /> and <typeparamref name="T4"/> and <typeparamref name="T5"/>
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    /// <typeparam name="T3">The third type</typeparam>
    /// <typeparam name="T4">The fourth type</typeparam>
    /// <typeparam name="T5">The fifth type</typeparam>
    public sealed class TypeList<T1, T2, T3, T4, T5> : TypeList
    {
        /// <summary>
        /// Gets 5 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/> and <typeparamref name="T4"/> and <typeparamref name="T5"/>
        /// </summary>
        /// <returns>An array of types with 5 elements</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns 6 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/><br /> and <typeparamref name="T4"/> and <typeparamref name="T5"/> and <typeparamref name="T6"/>
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    /// <typeparam name="T3">The third type</typeparam>
    /// <typeparam name="T4">The fourth type</typeparam>
    /// <typeparam name="T5">The fifth type</typeparam>
    /// <typeparam name="T6">The sixth type</typeparam>
    public sealed class TypeList<T1, T2, T3, T4, T5, T6> : TypeList
    {
        /// <summary>
        /// Gets 6 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/> and <typeparamref name="T4"/> and <typeparamref name="T5"/> and <typeparamref name="T6"/>
        /// </summary>
        /// <returns>An array of types with 6 elements</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns 7 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/><br /> and <typeparamref name="T4"/> and <typeparamref name="T5"/> and <typeparamref name="T6"/><br /> and <typeparamref name="T7"/>
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    /// <typeparam name="T3">The third type</typeparam>
    /// <typeparam name="T4">The fourth type</typeparam>
    /// <typeparam name="T5">The fifth type</typeparam>
    /// <typeparam name="T6">The sixth type</typeparam>
    /// <typeparam name="T7">The seventh type</typeparam>
    public sealed class TypeList<T1, T2, T3, T4, T5, T6, T7> : TypeList
    {
        /// <summary>
        /// Gets 7 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/> and <typeparamref name="T4"/> and <typeparamref name="T5"/> and <typeparamref name="T6"/> and <typeparamref name="T7"/>
        /// </summary>
        /// <returns>An array of types with 7 elements</returns>
        public override Type[] GetTypes()
        {
            return new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
        }
    }

    /// <summary>
    /// Utility class to have a list of generic types<br />
    /// Returns more than 7 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/><br /> and <typeparamref name="T4"/> and <typeparamref name="T5"/> and <typeparamref name="T6"/><br /> and <typeparamref name="T7"/><br />
    /// and then whatever the daisy chained <typeparamref name="TRest"/> returns.
    /// </summary>
    /// <typeparam name="T1">The first type</typeparam>
    /// <typeparam name="T2">The second type</typeparam>
    /// <typeparam name="T3">The third type</typeparam>
    /// <typeparam name="T4">The fourth type</typeparam>
    /// <typeparam name="T5">The fifth type</typeparam>
    /// <typeparam name="T6">The sixth type</typeparam>
    /// <typeparam name="T7">The seventh type</typeparam>
    /// <typeparam name="TRest">The TypeList of extra types</typeparam>
    public sealed class TypeList<T1, T2, T3, T4, T5, T6, T7, TRest> : TypeList
        where TRest : TypeList, new()
    {
        /// <summary>
        /// Gets more than 7 types <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/> and <typeparamref name="T4"/> and <typeparamref name="T5"/> and <typeparamref name="T6"/> and <typeparamref name="T7"/>
        /// and whatever is in <typeparamref name="TRest"/>.
        /// </summary>
        /// <returns>An array of types with more than 7 elements</returns>
        public override Type[] GetTypes()
        {
            List<Type> list = new List<Type>(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
            list.AddRange(new TRest().GetTypes());
            return list.ToArray();
        }
    }
}
