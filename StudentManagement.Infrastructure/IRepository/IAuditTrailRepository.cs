using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.IRepository
{
    public interface IAuditTrailRepository
    {
        void LogChange(AuditTrail auditTrail);

        Task<IEnumerable<Domain.Entities.AuditTrail>> GetAll();
    }
}