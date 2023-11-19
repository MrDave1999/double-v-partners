namespace Double.Partners.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentType
{
    [Description("CC.")]
    IdentityCard = 1,
    [Description("PA.")]
    Passport
}
