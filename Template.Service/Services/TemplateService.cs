﻿using Audit.Service.IServices;
using Template.Infrastructure.Repositories.Interfaces;
using Template.Model.Exceptions;
using Template.Model.Models.AuditModel;
using Template.Model.Models.AuditModel.EnumsForAudit;
using Template.Model.Models.Templates;
using Template.Model.Models.Templates.CommandModel;
using Template.Service.IServices;

namespace Template.Service.Services;

public class TemplateService : ITemplateService
{
    private readonly ITemplateRepository _TemplateRepository;
    private readonly IAuditService _AuditService;
    public TemplateService(ITemplateRepository templateRepository, IAuditService auditService)
    {
        _TemplateRepository = templateRepository;
        _AuditService = auditService;
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
            var result = await _AuditService.CreateAudit(new AuditModel()
            {
                Id = Guid.NewGuid(),
                UserName = createTemplateRequest.UserName,
                ActionType = ActionType.Create,
                ModelType = ModelType.AddTemplate,
                Entity = EntityName.Template,
                ActionDate = DateTime.Now,
            });
            if (result.IsSuccess)
            {
                await _TemplateRepository.AddAsync(template);
                return new TemplateResponse() { Text = createTemplateRequest.text, Id = template.Id };
            }
            else
            {
                throw new BadRequestException($"{result.SuccessMassage}");
            }
        }
    }

    public async Task<bool> DeleteTemplate(DeleteTemplateRequest deleteTemplateRequest)
    {
        var template = await _TemplateRepository.GetByIdAsync(deleteTemplateRequest.Id);
        if (template != null || template.IsDeleted) { throw new BadImageFormatException("template not found"); }

        template.IsDeleted = true;

        var result = await _AuditService.CreateAudit(new AuditModel()
        {
            Id = Guid.NewGuid(),
            UserName = deleteTemplateRequest.UserName,
            ActionType = ActionType.Delete,
            ModelType = ModelType.DeleteTemplate,
            Entity = EntityName.Template,
            ActionDate = DateTime.Now,
        });
        if (result.IsSuccess)
        {
            await _TemplateRepository.UpdateAsync(template);
            return true;
        }
        else
        {
            throw new BadRequestException($"{result.SuccessMassage}");
        }
    }

    public async Task<IEnumerable<TemplateResponse>?> GetAllTemplates(string UserName)
    {
        var commandresult = await _AuditService.CreateAudit(new AuditModel()
        {
            Id = Guid.NewGuid(),
            UserName = UserName,
            ActionType = ActionType.GetAll,
            ModelType = ModelType.GetTemplate,
            Entity = EntityName.Template,
            ActionDate = DateTime.Now,
        });
        if (commandresult.IsSuccess)
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
        else { throw new BadRequestException(); }
    }

    public async Task<TemplateResponse?> GetTemplateById(Guid id)
    {
        var commandresult = await _AuditService.CreateAudit(new AuditModel()
        {
            Id = Guid.NewGuid(),
            UserName = " ",
            ActionType = ActionType.GetOne,
            ModelType = ModelType.GetTemplate,
            Entity = EntityName.Template,
            ActionDate = DateTime.Now,
        });
        if (commandresult.IsSuccess)
        {
            var template = await _TemplateRepository.GetByIdAsync(id) ?? throw new Exception("Template not found");

            return new TemplateResponse() { Id = id, Text = template.Text };
        }
        else { throw new BadRequestException(); }

    }
    public async Task<TemplateResponse> UpdateTemplate(EditTemplateRequest editTemplateRequest)
    {
        var commandresult = await _AuditService.CreateAudit(new AuditModel()
        {
            Id = Guid.NewGuid(),
            UserName = editTemplateRequest.UserName,
            ActionType = ActionType.GetAll,
            ModelType = ModelType.GetTemplate,
            Entity = EntityName.Template,
            ActionDate = DateTime.Now,
        });
        if (commandresult.IsSuccess)
        {
            var template = await _TemplateRepository.GetByIdAsync(editTemplateRequest.Id);
            if (template != null || template.IsDeleted) { throw new BadImageFormatException("template not found"); }

            template.Text = editTemplateRequest.Text;

            await _TemplateRepository.UpdateAsync(template);

            return new TemplateResponse() { Text = template.Text, Id = template.Id };
        }
        else { throw new BadRequestException();}
    }
}