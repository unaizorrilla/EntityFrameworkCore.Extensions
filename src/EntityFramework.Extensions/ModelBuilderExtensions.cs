namespace EntityFrameworkCore.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ModelBuilderExtensions
    {
        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder builder, Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            var entityConfigurationTypes = assembly.GetTypes()
                 .Where(type => type.IsEntityConfiguration());

            foreach (var type in entityConfigurationTypes)
            {
                var configuration = Activator.CreateInstance(type) as IEntityConfiguration;

                configuration.Configure(builder);
            }
        }

        public static void AddEntityConfiguration<TEntity>(this ModelBuilder builder, EntityConfiguration<TEntity> configuration)
            where TEntity : class
        {
            builder.Entity<TEntity>(configuration.Configure);
        }
    }
}
