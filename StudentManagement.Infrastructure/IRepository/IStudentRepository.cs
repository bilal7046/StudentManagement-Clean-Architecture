using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken);

        Task<Student> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task AddAsync(Student student, CancellationToken cancellationToken);

        Task UpdateAsync(Student student, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}