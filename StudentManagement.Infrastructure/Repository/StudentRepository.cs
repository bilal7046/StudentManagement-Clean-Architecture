using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.Data;
using StudentManagement.Infrastructure.IRepository;
using System.Net;

namespace StudentManagement.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student, CancellationToken cancellationToken)
        {
            student.Id = Guid.NewGuid();
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC InsertStudent @StudentId = {student.Id}, @Name = {student.Name}, @Email = {student.Email}, @Address = {student.Address}");
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteStudent @StudentId = {id}");
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Student
                                .FromSqlRaw("EXEC GetAllStudents")
                                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _context.Student
                                    .FromSqlInterpolated($"EXEC GetStudentDetail @StudentId = {id}")
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task UpdateAsync(Student student, CancellationToken cancellationToken)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC UpdateStudent @StudentId = {student.Id}, @Name = {student.Name}, @Email = {student.Email}, @Address = {student.Address}"
        );
        }
    }
}