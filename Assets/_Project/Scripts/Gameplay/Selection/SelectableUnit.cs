using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour     //gắn lên unit
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    [SerializeField] private Color selectionColor = Color.green;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    public void Select()
    {
        spriteRenderer.color = selectionColor;
    }
    public void DeSelect()
    {
        spriteRenderer.color = originalColor;
    }
}
