using AutoMapper;
using MediatR;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;
using StudentManagement.Infrastructure.IRepository;

namespace Cowrk.Application.Features.Student.Handler.Commands
{
    public class UpdateStudentRequestHandler : IRequestHandler<UpdateStudentRequest, StudentRequest>
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UpdateStudentRequestHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<StudentRequest> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWorkRepository.StudentRepository.GetByIdAsync(request.StudentRequest.Id, cancellationToken);

            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {request.StudentRequest.Id} not found.");
            }

            _mapper.Map(request.StudentRequest, student);

            await _unitOfWorkRepository.StudentRepository.UpdateAsync(student, cancellationToken);

            await _unitOfWorkRepository.SaveAsync(cancellationToken);

            return _mapper.Map<StudentRequest>(student);
        }
    }
}