namespace CleanArchitecture.Domain.DTOs;

public sealed record IdentityResultModel(bool Succeeded, IEnumerable<string> Errors)
{
    public static IdentityResultModel Success() => new(true, Array.Empty<string>());
    public static IdentityResultModel Failure(IEnumerable<string> errors) => new(false, errors);
}
