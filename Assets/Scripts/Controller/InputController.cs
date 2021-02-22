using UnityEngine;
public class InputController : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayers;
    private Item itemSelected;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            itemSelected = HelperUtilities.GetComponentInMousePosition<Item>(itemLayers);
            if (!itemSelected)
                return;

            itemSelected?.Select();
        }
        else if (Input.GetMouseButton(0))
        {
            if (!itemSelected)
                return;

            itemSelected.Drag();
        }
        else if (Input.GetMouseButtonUp(0) || !Application.isFocused)
        {
            if (!itemSelected)
                return;

            itemSelected.Release();
            itemSelected = null;
        }

    }

}

