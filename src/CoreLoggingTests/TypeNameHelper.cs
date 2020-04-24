namespace CoreLoggingTests
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class TypeNameHelper
    {
        public static string GetTypeDisplayName(object item, bool fullName = true)
        {
            return item != null ?
                GetTypeDisplayName(
                    item.GetType(),
                    fullName,
                    false,
                    true,
                    '+')
                : (string)null;
        }

        public static string GetTypeDisplayName(
            Type type,
            bool fullName = true,
            bool includeGenericParameterNames = false,
            bool includeGenericParameters = true,
            char nestedTypeDelimiter = '+')
        {
            var shortAssemblyName = "Microsoft.Extensions.Logging.Abstractions";
            var assembly = Assembly.Load(shortAssemblyName);
            if (assembly is null) throw new NullReferenceException(nameof(assembly));

            var typeNameHelper = assembly.GetType("Microsoft.Extensions.Internal.TypeNameHelper");
            if (typeNameHelper is null) throw new NullReferenceException(nameof(typeNameHelper));

            var methodInfo = typeNameHelper.GetMethods().Last(m => m.Name == "GetTypeDisplayName");
            if (methodInfo is null) throw new NullReferenceException(nameof(methodInfo));

            var displayName = (string)methodInfo.Invoke(null,
                new object[]
                {
                    type,
                    fullName,
                    includeGenericParameterNames,
                    includeGenericParameters,
                    nestedTypeDelimiter
                });

            return displayName;
        }
    }
}