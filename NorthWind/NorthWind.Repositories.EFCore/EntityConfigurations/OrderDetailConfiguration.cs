using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.Repositories.EFCore.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => new { od.OrderId, od.ProductId });

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);
        }
    }
}
