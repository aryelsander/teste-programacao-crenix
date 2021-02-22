using UnityEngine;

public class GameItem : Item
{
    [SerializeField] private UIItem uiItem;
    private SpriteRenderer spriteRenderer;
    public UIItem UIItem { get => uiItem; }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void Select()
    {
        transform.SetParent(null);
        transform.position = HelperUtilities.GetMousePosition();
        spriteRenderer.sortingOrder = 1;
        itemSlot.RemoveItem();
    }
    protected override void GameSlotCollision(GameSlot gameSlot)
    {
        itemSlot.RemoveItem();
        gameSlot.SetSlot(this);
    }
    protected override void InventorySlotCollision(InventorySlot inventorySlot)
    {
        itemSlot.RemoveItem();
        UIItem uiItemInstance = Instantiate(uiItem, inventorySlot.transform);
        inventorySlot.SetSlot(uiItemInstance);
        Destroy(gameObject);
    }
    protected override void EndDrag()
    {
        spriteRenderer.sortingOrder = 0;
    }
}

