using System.Globalization;
using Template.Model.Models.Templates.CommandModel;

namespace Template.Service.IServices;

public interface ITemplateService
{
    Task<TemplateResponse> CreateTemplate(CreateTemplateRequest createTemplateRequest);
    Task<TemplateResponse> UpdateTemplate(EditTemplateRequest editTemplateRequest);
    Task<bool> DeleteTemplate(DeleteTemplateRequest deleteTemplateRequest);
    Task<IEnumerable<TemplateResponse>?> GetAllTemplates(string UserName);
    Task<TemplateResponse?> GetTemplateById(Guid id);
    //Task<IEnumerable<TemplateResponse>?> SearchTemplate(Guid id);
}
