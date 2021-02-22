public class InventorySlot : Slot
{
    private UIItem item;
    public override void RemoveItem()
    {
        base.RemoveItem();
        item = null;
    }
    protected override void GetItem(Item item)
    {
        this.item = (UIItem)item;
    }
    public UIItem Item { get => item;}
}