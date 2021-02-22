using System;
using UnityEngine;

public class GameSlot : Slot
{
    [SerializeField] private RotateDirection rotateDirection;
    private GameItem item;
    public Action OnSetItem;
    public Action OnRemoveItem;
    public GameItem Item { get => item;}

    public override void RemoveItem()
    {
        OnRemoveItem?.Invoke();
        base.RemoveItem();
        item = null;
    }
    protected override void GetItem(Item item)
    {
        this.item = (GameItem)item;
        OnSetItem?.Invoke();
    }
    public void RotateItem(float speed)
    {
        item.transform.Rotate(0, 0,speed * Time.deltaTime * (int)rotateDirection);
    }

    private enum RotateDirection
    {
        Left = 1,
        Right = -1,
    }
}

