namespace ItemAPI;

public class ItemService
{
    private readonly ItemDbContext _itemDbContext;

    public ItemService(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    public IEnumerable<Items> GetAllItems()
    {
        return _itemDbContext.Items;
    }

    public Items GetItemById(int id)
    {
        return _itemDbContext.Items.FirstOrDefault(item => item.Id == id);
    }

    public Items CreateItem(Items item)
    {
        _itemDbContext.Items.Add(item);
        _itemDbContext.SaveChanges();
        return item;
    }

    public Items UpdatePrice(int id, decimal price)
    {
        var existingItem = _itemDbContext.Items.FirstOrDefault(i => i.Id == id);
        if (existingItem == null)
        {
            return null;
        }
        existingItem.Price = price;
        _itemDbContext.Items.Update(existingItem);
        _itemDbContext.SaveChanges();
        return existingItem;
    }

    public Items UpdateItem(int id, Items item)
    {
        var existingItem = _itemDbContext.Items.FirstOrDefault(i => i.Id == id);
        if (existingItem == null)
        {
            return null;
        }
        existingItem.Name = item.Name;
        existingItem.Description = item.Description;
        existingItem.Price = item.Price;
        _itemDbContext.Items.Update(existingItem);
        _itemDbContext.SaveChanges();
        return existingItem;
    }
    
    public void DeleteItem(int id)
    {
        var item = _itemDbContext.Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return;
        }
        _itemDbContext.Items.Remove(item);
        _itemDbContext.SaveChanges();
    }
}
