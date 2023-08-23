﻿using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.DataBaseHelper;
using Template.Infrastructure.Repositories.Interfaces;
using Template.Model.Exceptions;
using Template.Model.Models;

namespace Template.Infrastructure.Repositories.Repository;

public class TemplateRepository : RepositoryBase<TemplateModel>, ITemplateRepository
{
    public TemplateRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<TemplateModel>> LoadAsync()
    {
        var authors = await _context.Templates.Where(x => !x.IsDeleted).ToListAsync();

        if (authors == null)
            throw new NotFoundException("Authors Not Found");

        return authors;
    }
}