using AutoMapper;
using MediatR;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;
using StudentManagement.Infrastructure.IRepository;

namespace Cowrk.Application.Features.Student.Handler.Queries
{
    public class GetStudentListRequstHandler : IRequestHandler<GetStudentsRequest, IEnumerable<StudentRequest>>
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public GetStudentListRequstHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentRequest>> Handle(GetStudentsRequest request, CancellationToken cancellationToken)
        {
            var studentEntities = await _unitOfWorkRepository.StudentRepository.GetAllAsync(cancellationToken);

            var studentRequests = _mapper.Map<IEnumerable<StudentRequest>>(studentEntities);

            return studentRequests;
        }
    }
}