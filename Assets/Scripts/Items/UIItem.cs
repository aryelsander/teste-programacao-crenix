using UnityEngine;

public class UIItem : Item
{
    [SerializeField]private GameItem gameItem;
    public GameItem GameItem { get => gameItem;}
    public override void Select()
    {
        Canvas canvas = GetComponentInParent<Inventory>().SelectedCanvas;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        Vector2 pos = HelperUtilities.GetMousePosition();
        transform.position = pos;
    }
    protected override void GameSlotCollision(GameSlot gameSlot)
    {
        itemSlot.RemoveItem();
        GameItem gameItemInstance = Instantiate(gameItem, gameSlot.transform);
        gameSlot.SetSlot(gameItemInstance);
        Destroy(gameObject);
    }
    protected override void InventorySlotCollision(InventorySlot inventorySlot)
    {
        itemSlot.RemoveItem();
        inventorySlot.SetSlot(this);
    }
    protected override void EndDrag()
    {

    }
}

