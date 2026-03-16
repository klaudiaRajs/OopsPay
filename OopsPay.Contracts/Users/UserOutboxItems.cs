using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Users;

[Table("GetUserDetails", Schema = "UserOutbox")]
public class GetUserDetails : OutboxItem{}