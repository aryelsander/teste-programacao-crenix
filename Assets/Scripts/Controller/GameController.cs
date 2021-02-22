using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private NuggetUI nuggetUI;
    [SerializeField] private Button resetButton;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameSlot[] gameSlots;
    
    private Coroutine rotationCoroutine;
    private bool active = false;

    private void Awake()
    {
        resetButton.onClick.AddListener(() => ResetGame());
        foreach (GameSlot gameSlot in gameSlots)
        {
            gameSlot.OnSetItem += CheckIsComplete;
            gameSlot.OnRemoveItem += CheckIsNotComplete;
        }
    }
    private void ResetGame()
    {
        foreach (InventorySlot inventorySlot in inventory.InventorySlots)
        {
            if (inventorySlot.IsInUse)
                continue;

            foreach (GameSlot gameSlot in gameSlots)
            {
                if (gameSlot.IsInUse)
                {
                    UIItem uiItemInstance = Instantiate(gameSlot.Item.UIItem, inventorySlot.transform);
                    Destroy(gameSlot.Item.gameObject);
                    gameSlot.RemoveItem();
                    inventorySlot.SetSlot(uiItemInstance);
                    break;
                }
            }
        }
    }
    private void CheckIsComplete()
    {
        foreach (GameSlot gameSlot in gameSlots)
        {
            if (!gameSlot.IsInUse)
                return;
        }
        active = true;
        nuggetUI.SetText("YAY, PARABÉNS. TASK CONCLUÍDA!", 0.03f);
        rotationCoroutine = StartCoroutine(RotationObjects());
    }
    private IEnumerator RotationObjects()
    {
        while (active)
        {
            foreach (GameSlot gameSlot in gameSlots)
            {
                gameSlot.RotateItem(speed);
            }
            yield return null;
        }
    }
    private void CheckIsNotComplete()
    {
        if (rotationCoroutine != null)
        {
            nuggetUI.SetText("ENCAIXE AS ENGRENAGENS EM QUALQUER ORDEM!", 0.03f);
            StopCoroutine(rotationCoroutine);
            rotationCoroutine = null;
        }
    }
}

