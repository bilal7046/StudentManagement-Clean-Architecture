using StudentManagement.Infrastructure.Data;
using StudentManagement.Infrastructure.IRepository;

namespace StudentManagement.Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository, IDisposable
    {
        private StudentContext _context;
        private IStudentRepository _studentRepository;

        public UnitOfWorkRepository(StudentContext context)
        {
            _context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                }
                return _studentRepository;
            }
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}