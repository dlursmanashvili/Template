using System.ComponentModel.DataAnnotations;

namespace Template.Model.Models.CommandModel;

public class CreateTemplateRequest
{
    public string Firstname { get; set; }
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

}

