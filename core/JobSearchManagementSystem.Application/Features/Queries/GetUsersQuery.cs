// In JobSearchManagementSystem.Application.Features.Queries
using JobSearchManagementSystem.Application.Dtos;
using MediatR;

public class GetUsersQuery : IRequest<IEnumerable<UserViewDto>>
{
    
}
