using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Products;

[Table("GetProductDetails", Schema = "ProductOutbox")]
public class GetProductDetails : OutboxItem{}