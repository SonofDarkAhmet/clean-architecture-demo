using CleanArchitecture.Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class UserRole :  Entity
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role Role { get; set; }
}
