using UnityEngine;

public abstract class Slot : MonoBehaviour
{
    protected bool isInUse;

    public bool IsInUse { get => isInUse; }

    public virtual void SetSlot<T>(T item) where T:Item
    {
        isInUse = true;
        item.transform.SetParent(transform);
        item.SetItem(this);
        GetItem(item);
        item.transform.SetParent(transform);
        item.transform.position = transform.position;
    }
    protected abstract void GetItem(Item item);
    public virtual void RemoveItem()
    {
        isInUse = false;

    }
}

