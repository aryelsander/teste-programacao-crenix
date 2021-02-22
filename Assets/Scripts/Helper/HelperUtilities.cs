using UnityEngine;
using System.Collections.Generic;

public static class HelperUtilities
{
    public static Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public static Collider2D GetCollider2DInMousePosition(LayerMask layerMask)
    {
        Collider2D collider = Physics2D.OverlapPoint(GetMousePosition(), layerMask);
        return collider;
    } 
    public static Collider2D[] GetColliders2DInMousePosition(LayerMask layerMask)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(GetMousePosition(), layerMask);
        return colliders;
    }
    public static T GetComponentInMousePosition<T>(LayerMask layerMask)
    {
        Collider2D collider = GetCollider2DInMousePosition(layerMask);
        T component = collider? collider.GetComponent<T>():default(T);
        return component;
    }
    public static T[] GetComponentsInMousePosition<T>(LayerMask layermask)
    {
        Collider2D[] colliders2D = GetColliders2DInMousePosition(layermask);
        List<T> components = new List<T>();
        for (int i = 0; i < colliders2D.Length; i++)
        {
            if (colliders2D[i])
            {
                if(colliders2D[i].GetComponent<T>() != null)
                {
                    components.Add(colliders2D[i].GetComponent<T>());
                }
            }
        }
        return components.ToArray();
    }
}
