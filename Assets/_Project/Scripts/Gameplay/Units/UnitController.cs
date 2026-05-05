using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour     // nhập input / điều khiển
{
    private UnitMovement movement;
    private SelectionManager selectionManager;

    private void Awake()
    {
        movement = GetComponent<UnitMovement>();
        selectionManager = FindObjectOfType<SelectionManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Chuột phải
        {
            if (selectionManager.GetSelectedUnit() == GetComponent<SelectableUnit>())
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                movement.MoveTo(mousePos);
            }
        }
    }
}