using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Application;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Infrastructure.Authentication;

public sealed class UserProvider : IUserProvider<User>
{
    private readonly UserManager<User> _userManager;
    public UserProvider(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IdentityResultModel> CreateAsync(User user, string password)
    {
        IdentityResult result = await _userManager.CreateAsync(user, password);

        return result.Succeeded
            ? IdentityResultModel.Success()
            : IdentityResultModel.Failure(result.Errors.Select(e => e.Description));
    }
    public async Task<User?> FindByUserNameOrEmailAsync(string value, CancellationToken ct)
    {
        User? user = await _userManager.FindByNameAsync(value)
            ?? await _userManager.FindByEmailAsync(value);

        return user;
    }
    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
    public async Task<User?> FindByIdAsync(string id, CancellationToken ct)
    {
        User? user = await _userManager.FindByIdAsync(id);
        return user;
    }
}
