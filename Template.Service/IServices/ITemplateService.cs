using Template.Model.Models.CommandModel;

namespace Template.Service.IServices;

public interface ITemplateService
{
    Task<TemplateResponse> CreateTemplate(CreateTemplateRequest createTemplateRequest);
    Task<TemplateResponse> UpdateTemplate(EditTemplateRequest editTemplateRequest);
    Task<bool> DeleteTemplate(DeleteTemplateRequest deleteTemplateRequest);
    Task<IEnumerable<TemplateResponse>?> GetAllTemplates();
    Task<TemplateResponse?> GetTemplateById(Guid id);
    //Task<IEnumerable<TemplateResponse>?> SearchTemplate(Guid id);
}
