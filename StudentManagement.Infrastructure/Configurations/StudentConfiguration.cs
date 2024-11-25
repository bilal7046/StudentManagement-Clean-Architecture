using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(z => z.Id);
            builder.Property(z => z.Name).IsRequired();
            builder.Property(z => z.Email).IsRequired();
            builder.Property(z => z.Address).IsRequired();
        }
    }
}