using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Users;

[Table("Users", Schema = "User")]
public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}