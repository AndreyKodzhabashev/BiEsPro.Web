namespace BiEsPro.Data.Models.FluentAPIModelConfigurations
{
    using BiEsPro.Data.Models.OrderElements;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrdersitemsConfig : IEntityTypeConfiguration<OrdersItems>
    {
        public void Configure(EntityTypeBuilder<OrdersItems> builder)
        {
            builder.HasKey(x => new { x.ItemId, x.OrderId });

            builder.HasOne(x => x.Item)
                 .WithMany(x => x.Orders)
                 .HasForeignKey(x => x.ItemId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                 .WithMany(x => x.Materials)
                 .HasForeignKey(x => x.OrderId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
