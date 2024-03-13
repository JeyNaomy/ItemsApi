
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ItemAPI;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Items>> GetAllItems()
    {
        if (_itemService.GetAllItems().ToList().Count() == 0)
        {
            return NotFound(new {Error = "No items found"});
        }
        return Ok(_itemService.GetAllItems().ToList());
    }

    [HttpGet("{Id}")]
    public ActionResult<Items> GetItemById(int Id)
    {
      var item = _itemService.GetItemById(Id);
        if (item == null)
        {
            return NotFound(new {Error = "Item not found"});
        }
        return Ok(item);

    }

    [HttpPost]
    public ActionResult<Items> CreateItem([FromBody] Items item)
    {
           var newItem = _itemService.CreateItem(item);
           return CreatedAtAction(nameof(CreateItem), new {Id = newItem.Id});
    }



    [HttpPatch("{Id}")]
    public ActionResult<Items> UpdatePrice(int Id, [FromBody] decimal price)
    {
        var updatedItem = _itemService.UpdatePrice(Id, price);
        if (updatedItem == null)
        {
            return NotFound(new {Error = "Item not found"});
        }
        return Ok(updatedItem);
    }
    
    [HttpPut("{Id}")]
    public ActionResult<Items> UpdateItem(int Id, [FromBody] Items item)
    {
        var updatedItem = _itemService.UpdateItem(Id, item);
        if (updatedItem == null)
        {
            return NotFound(new {Error = "Item not found"});
        }
        return Ok(updatedItem);
    }

    [HttpDelete("{Id}")]
    public ActionResult DeleteItem(int Id)
    {
        _itemService.DeleteItem(Id);
        return NoContent();
    }


}
