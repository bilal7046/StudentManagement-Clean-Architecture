using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.IRepository;

namespace StudentManagement.Pages.AuditTrail
{
    public class IndexModel : PageModel
    {
        private readonly IAuditTrailRepository _auditTrailRepository;
        public IEnumerable<Domain.Entities.AuditTrail> AuditTrails;

        public IndexModel(IAuditTrailRepository auditTrailRepository)
        {
            _auditTrailRepository = auditTrailRepository;
        }

        public async Task OnGet()
        {
            AuditTrails = await _auditTrailRepository.GetAll();
        }
    }
}