using AutoMapper;
using MediatR;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;
using StudentManagement.Infrastructure.IRepository;

namespace StudentManagement.Application.Features.Student.Handler.Commands
{
    public class CreateStudentRequestCommandHandler : IRequestHandler<CreateStudentRequest, StudentRequest>
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public CreateStudentRequestCommandHandler(IUnitOfWorkRepository unitOfWorkRepository,
                                                  IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<StudentRequest> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Domain.Entities.Student>(request.StudentRequest);

            await _unitOfWorkRepository.StudentRepository.AddAsync(student, cancellationToken);

            await _unitOfWorkRepository.SaveAsync(cancellationToken);

            return _mapper.Map<StudentRequest>(student);
        }
    }
}