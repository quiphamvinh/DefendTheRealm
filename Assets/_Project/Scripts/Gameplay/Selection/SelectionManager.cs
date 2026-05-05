using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour       //quản lý toàn bộ selection
{
    private SelectableUnit currentSelected;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
    }
    private void HandleSelection()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)
        {
            SelectableUnit unit = hit.collider.GetComponent<SelectableUnit>();
            if (unit != null) 
            {
                Select(unit);
                return;
            }
        }
        // Click vào đất → bỏ chọn
        DeselectCurrent();
    }
    private void Select(SelectableUnit unit)
    {
        if (currentSelected != null)
        {
            currentSelected.DeSelect();
        }

        currentSelected = unit;
        currentSelected.Select();
    }
    private void DeselectCurrent()
    {
        if (currentSelected != null)
        {
            currentSelected.DeSelect();
            currentSelected = null;
        }
    }
    public SelectableUnit GetSelectedUnit()
    {
        return currentSelected;
    }
}
