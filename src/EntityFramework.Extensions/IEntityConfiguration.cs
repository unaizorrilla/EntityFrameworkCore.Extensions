using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Extensions
{
    public interface IEntityConfiguration
    {
        void Configure(ModelBuilder builder);
    }                                               

    public abstract class  EntityConfiguration<TEntitty> :IEntityConfiguration
        where TEntitty : class
    {
        public void Configure(ModelBuilder builder)
        {
            Configure(builder.Entity<TEntitty>());
        }

        public abstract void Configure(EntityTypeBuilder<TEntitty> builder);
    }
}
