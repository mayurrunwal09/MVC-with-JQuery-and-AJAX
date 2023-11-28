using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Domain.Mappers
{
    public class LoginUserMapper:IEntityTypeConfiguration<LoginUser>
    {
        public void Configure(EntityTypeBuilder<LoginUser> builder)
        {
            builder.HasKey(L_Id => L_Id.Id)
                .HasName("pk_UserId");
            builder.Property(L_Id => L_Id.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserId")
                .HasColumnType("INT");

            builder.Property(L_Admin => L_Admin.IsAdmin)
                .HasColumnName("IsAdmin")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(L_UserSalt => L_UserSalt.UserSalt)
                .HasColumnName("UserSalt")
                .HasColumnType("Nvarchar(100)")
                .IsRequired();

            builder.Property(L_UserPassword => L_UserPassword.UserPassword)
                .HasColumnName("UserPassword")
                .HasColumnType("Nvarchar(500)")
                .IsRequired();

            builder.Property(L_UserLastLogin => L_UserLastLogin.UserLastLoginDateTime)
                .HasColumnName("UserLastLogin")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(L_UserLastLoginIpAddress => L_UserLastLoginIpAddress.UserLastLoginIpAddress)
                .HasColumnName("UserLastLoginIpAddress")
                .HasColumnType("NVARCHAR(500)")
                .IsRequired();
        }
    }
}
