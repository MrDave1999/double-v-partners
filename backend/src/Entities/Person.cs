namespace Double.Partners.Entities;

public class Person
{
    public int Id { get; set; }
    public string Names { get; set; }
    public string LastNames {  get; set; }
    public string FullName { get; set; }
    public string Document { get; set; }
    public DocumentType DocumentType { get; set; } = DocumentType.IdentityCard;
    public string FullDocument { get; set; }
    public string Email { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}
