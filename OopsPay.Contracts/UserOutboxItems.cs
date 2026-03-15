using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts;

[Table("GetUserDetails", Schema = "UserOutbox")]
public class GetUserDetails : OutboxItem{}