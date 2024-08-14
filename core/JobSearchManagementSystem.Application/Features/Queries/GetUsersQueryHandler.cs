// In JobSearchManagementSystem.Application.Features.Queries
using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserViewDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserViewDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await _unitOfWork.UserRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserViewDto>>(userDetails);
    }
}
