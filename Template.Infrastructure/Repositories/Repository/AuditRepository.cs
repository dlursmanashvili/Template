using Audit.Infrastructure.Repositories.Interfaces;
using Template.Infrastructure.DataBaseHelper;
using Template.Infrastructure.Repositories.Repository;
using Template.Model.Models.AuditModel;

namespace Audit.Infrastructure.Repositories.Repository;

public class AuditRepository : RepositoryBase<AuditModel>, IAuditRepository
{
    public AuditRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task AddAsync(AuditModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<AuditModel?> GetByIdAsync(object id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuditModel>> LoadAsync()
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(AuditModel entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveById(object id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(AuditModel entity)
    {
        throw new NotImplementedException();
    }
}
