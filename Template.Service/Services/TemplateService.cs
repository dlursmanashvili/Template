using Template.Infrastructure.Repositories.Interfaces;
using Template.Model.Exceptions;
using Template.Model.Models;
using Template.Model.Models.CommandModel;
using Template.Service.IServices;

namespace Template.Service.Services;

public class TemplateService : ITemplateService
{
    private readonly ITemplateRepository _TemplateRepository;

    public TemplateService(ITemplateRepository templateRepository)
    {
        _TemplateRepository = templateRepository;
    }

    public async Task<TemplateResponse> CreateTemplate(CreateTemplateRequest createTemplateRequest)
    {
        var template = new TemplateModel()
        {
            Id = Guid.NewGuid(),
            Text = createTemplateRequest.text,
            IsDeleted = false,
        };
        if (createTemplateRequest.text == null || createTemplateRequest.text == " ")
        {
            throw new BadRequestException("please imput normal text");
        }
        else
        {
            await _TemplateRepository.AddAsync(template);
            return new TemplateResponse() { Text = createTemplateRequest.text,  Id = template.Id };
        }
    }

    public async Task<bool> DeleteTemplate(DeleteTemplateRequest deleteTemplateRequest)
    {
        var template = await _TemplateRepository.GetByIdAsync(deleteTemplateRequest.Id);
        if (template != null || template.IsDeleted) { throw new BadImageFormatException("template not found"); }

        template.IsDeleted = true;
        await _TemplateRepository.UpdateAsync(template);
        return true;
    }

    public async Task<IEnumerable<TemplateResponse>?> GetAllTemplates()
    {
        var result = await _TemplateRepository.LoadAsync();
        if (result.Any())
        {
            return result.Select(x => new TemplateResponse()
            {
               Text = x.Text,
                Id = x.Id
            });
        }
        return null;
    }

    public async Task<TemplateResponse?> GetTemplateById(Guid id)
    {
        var template = await _TemplateRepository.GetByIdAsync(id) ?? throw new Exception("Template not found");

        return new TemplateResponse() { Id = id, Text = template.Text };
    }



    public async Task<TemplateResponse> UpdateTemplate(EditTemplateRequest editTemplateRequest)
    {
        var template = await _TemplateRepository.GetByIdAsync(editTemplateRequest.Id);
        if (template != null || template.IsDeleted) { throw new BadImageFormatException("template not found"); }

        template.Text = editTemplateRequest.Text;

        await _TemplateRepository.UpdateAsync(template);

        return new TemplateResponse() { Text = template.Text , Id = template.Id };
    }
}