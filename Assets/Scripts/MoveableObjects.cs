using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAll : MonoBehaviour
{
    private Transform beingDragged = null;
    private Vector3 offset;
    [SerializeField] private LayerMask moveableLayers;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, LayerMask.GetMask("Moveable"));

            if (hit)
            {
                beingDragged = hit.transform;
                offset = beingDragged.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            beingDragged = null;
        }

        if (beingDragged != null)
        {
            beingDragged.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}