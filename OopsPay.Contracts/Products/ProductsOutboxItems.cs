using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts;

[Table("GetProductDetails", Schema = "ProductOutbox")]
public class GetProductDetails : OutboxItem{}