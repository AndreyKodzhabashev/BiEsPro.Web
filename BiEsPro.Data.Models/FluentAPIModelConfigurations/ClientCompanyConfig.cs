using BiEsPro.Data.Models.ClientElements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiEsPro.Data.Models.FluentAPIModelConfigurations
{
    public class ClientCompanyConfig : IEntityTypeConfiguration<ClientCompany>
    {
        public void Configure(EntityTypeBuilder<ClientCompany> builder)
        {
            builder.HasOne(x => x.City)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VatRegistration)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.VatRegistrationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
