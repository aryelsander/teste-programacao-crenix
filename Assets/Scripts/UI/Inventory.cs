using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private Item[] startItems;
    [SerializeField] private Canvas selectedCanvas;
    public InventorySlot[] InventorySlots { get => inventorySlots;}
    public Canvas SelectedCanvas { get => selectedCanvas;}

    private void Awake()
    {
        for (int i = 0; i < startItems.Length; i++)
        {
            Item itemInstance = Instantiate(startItems[i], inventorySlots[i].transform);
            inventorySlots[i].SetSlot(itemInstance);
        }
    }
    

}
