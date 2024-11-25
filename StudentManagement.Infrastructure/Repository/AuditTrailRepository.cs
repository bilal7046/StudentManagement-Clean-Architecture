using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.Data;
using StudentManagement.Infrastructure.IRepository;

namespace StudentManagement.Infrastructure.Repository
{
    public class AuditTrailRepository : IAuditTrailRepository
    {
        private StudentContext _context;

        public AuditTrailRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditTrail>> GetAll()
        {
            return await _context.AuditTrail.ToListAsync();
        }

        public void LogChange(AuditTrail auditTrail)
        {
            _context.AuditTrail.Add(auditTrail);
            _context.SaveChanges();
        }
    }
}