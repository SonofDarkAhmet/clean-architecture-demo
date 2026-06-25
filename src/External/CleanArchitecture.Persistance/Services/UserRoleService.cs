using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Entities;
using GenericRepository;

namespace CleanArchitecture.Persistance.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleService(IUserRoleRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = new()
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        await _userRepository.AddAsync(userRole, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
