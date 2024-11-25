using AutoMapper;
using MediatR;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;
using StudentManagement.Infrastructure.IRepository;

namespace Cowrk.Application.Features.Student.Handler.Queries
{
    public class GetStudentByIdRequestHandler : IRequestHandler<GetStudentByIdRequest, StudentRequest>
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public GetStudentByIdRequestHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<StudentRequest> Handle(GetStudentByIdRequest request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWorkRepository.StudentRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<StudentRequest>(student);
        }
    }
}