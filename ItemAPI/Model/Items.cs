using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemAPI;

[Table("Items")]
public class Items
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private decimal _price;
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public Items(int id, string name, string description, decimal price)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("Id must be greater than 0");
        }

        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }
    public Items()
    {
    }
}
