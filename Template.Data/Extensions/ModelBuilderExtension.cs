using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder) 
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("3b0e25f449354a73ad0774f836843489"), Name = "UserDefault", Email = "userdefault@template.com" }
                );

            return builder;
        }
    }
}
