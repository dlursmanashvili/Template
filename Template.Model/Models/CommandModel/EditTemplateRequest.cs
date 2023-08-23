namespace Template.Model.Models.CommandModel;

public class EditTemplateRequest
{
    public Guid AuthorID { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
