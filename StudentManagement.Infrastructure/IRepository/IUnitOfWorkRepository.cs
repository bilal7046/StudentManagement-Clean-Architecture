namespace StudentManagement.Infrastructure.IRepository
{
    public interface IUnitOfWorkRepository
    {
        IStudentRepository StudentRepository { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}