using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {

            builder.HasData(
                new Staff { Id=1,FirstName="Ali",LastName="Koç",DateOfBirth=DateTime.Now,City="Konya",Country="selçuklu",Email="ali@mail.com",Province="hüsamettin celebi",Phone="12345678901",AddressLine1="konya selçuklu"}
                );
        }
    }
}
