using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Application.Abstractions;

public interface IUserProvider<T> where T : User
{
    Task<T> FindByUserNameOrEmailAsync(string value, CancellationToken ct);
    Task<bool> CheckPasswordAsync(T user, string password);
    Task<IdentityResultModel> CreateAsync(T user, string password);
    Task<T> FindByIdAsync(string id, CancellationToken ct);
}
