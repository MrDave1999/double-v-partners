namespace Double.Partners.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .Property(p => p.DocumentType)
            .HasColumnType("ENUM('CC.', 'PA.')")
            .HasConversion(
                v => v.AsString(EnumFormat.Description),
                v => Enums.Parse<DocumentType>(v, true, EnumFormat.Description));

        var person = new Person
        {
            Id           = 1,    
            Names        = "David Sebastián",
            LastNames    = "Román Amariles",
            FullName     = "Román Amariles David Sebastián",
            Document     = "1126564742",
            DocumentType = DocumentType.IdentityCard,
            FullDocument = "CC. 1126564742",
            Email        = "daveseva2010@hotmail.es"
        };

        builder.HasData(person);
    }
}
