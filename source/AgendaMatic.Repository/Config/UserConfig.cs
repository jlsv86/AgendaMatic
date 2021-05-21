using AgendaMatic.Domain.Entities;
using AgendaMatic.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMatic.Repository.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User).ToDatabaseFormat());

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.UserId)
                .IsRequired()
                .ValueGeneratedNever()
                .HasColumnName(nameof(User.UserId).ToDatabaseFormat());

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName(nameof(User.Email).ToDatabaseFormat());

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName(nameof(User.Password).ToDatabaseFormat());
        }
    }
}
