using System.ComponentModel.DataAnnotations;

namespace amaZen.Models
{
  public class Product : Virtual<int>
  {

    [Required]
    public string Name { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public string Sku { get; set; }
    public string Description { get; set; }
  }

  public class ProductViewModel : Product
  {
    public int? WarehouseProductId { get; set; }
    public string? location { get; set; }
  }
}