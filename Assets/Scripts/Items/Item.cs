using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected LayerMask slotLayer;
    public Action<GameSlot> OnGameSlot;
    public Action<InventorySlot> OnInventorySlot;
    protected Slot itemSlot;
    public virtual void SetItem(Slot itemSlot)
    {
        this.itemSlot = itemSlot;
        transform.SetParent(itemSlot.transform);
        transform.position = itemSlot.transform.position;
    }
    protected virtual void Undo()
    {
        transform.SetParent(itemSlot.transform);
        transform.position = itemSlot.transform.position;
        itemSlot.SetSlot(this);
    }
    public abstract void Select();
    public virtual void Drag()
    {
        Vector2 pos = HelperUtilities.GetMousePosition();
        transform.position = pos;
    }
    public virtual void Release()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider2D = Physics2D.OverlapPoint(mousePos, slotLayer);
        if (collider2D)
        {
            if (collider2D.GetComponent<GameSlot>())
            {
                GameSlot gameSlot = collider2D.GetComponent<GameSlot>();
                if (!gameSlot.IsInUse)
                {
                    OnGameSlot?.Invoke(gameSlot);
                }
                else
                {
                    //transform.SetParent(itemSlot.transform);
                    Undo();
                }
            }
            else if (collider2D.GetComponent<InventorySlot>())
            {
                InventorySlot inventorySlot = collider2D.GetComponent<InventorySlot>();
                if (!inventorySlot.IsInUse)
                {
                    OnInventorySlot?.Invoke(inventorySlot);
                }
                else
                {
                    // transform.SetParent(itemSlot.transform);
                    Undo();
                }
            }

        }
        else
        {
            // transform.SetParent(itemSlot.transform);
            Undo();
        }
        EndDrag();
    }
    protected abstract void GameSlotCollision(GameSlot gameSlot);
    protected abstract void InventorySlotCollision(InventorySlot inventorySlot);
    protected abstract void EndDrag();
    protected virtual void OnEnable()
    {
        OnGameSlot += GameSlotCollision;
        OnInventorySlot += InventorySlotCollision; 
    }
    protected virtual void OnDisable()
    {
        OnGameSlot -= GameSlotCollision;
        OnInventorySlot -= InventorySlotCollision;
    }
}