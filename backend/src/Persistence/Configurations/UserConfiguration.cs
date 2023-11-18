namespace Double.Partners.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.Password)
            .HasColumnType("varchar(64)");

        builder
            .HasIndex(u => u.Name)
            .IsUnique();

        var testPassword = "123456789";
        var user = new User
        {
            Id       = 1,
            Name     = "MrDave1999",
            Password = PasswordHasher.HashPassword(testPassword)
        };

        builder.HasData(user);
    }
}
