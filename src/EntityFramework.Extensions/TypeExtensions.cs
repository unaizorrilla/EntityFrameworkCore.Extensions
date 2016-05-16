using System;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCore.Extensions
{
    static class TypeExtensions
    {
        public static bool IsEntityConfiguration(this Type type)
        {
            if (type.GetInterfaces()
                .Any())
            {
                var entityConfigurations = type.GetInterfaces()
                    .Where(t =>  typeof(IEntityConfiguration).IsAssignableFrom(t));

                return entityConfigurations.Any();
            }

            return false;
        }
    }
}
