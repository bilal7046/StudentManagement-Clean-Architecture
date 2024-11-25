using AutoMapper;
using MediatR;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Infrastructure.IRepository;

namespace Cowrk.Application.Features.Student.Handler.Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentRequest, bool>
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWorkRepository.StudentRepository.GetByIdAsync(request.Id, cancellationToken);

            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {request.Id} not found.");
            }

            await _unitOfWorkRepository.StudentRepository.DeleteAsync(request.Id, cancellationToken);

            return await _unitOfWorkRepository.SaveAsync(cancellationToken) > 0;
        }
    }
}