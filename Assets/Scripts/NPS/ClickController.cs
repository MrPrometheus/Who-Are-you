using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    private NPC NPC_;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        NPC_ = transform.parent.GetComponent<NPC>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnGUI()
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
            if (boxCollider2D.OverlapPoint(wp))
                NPC_.StartDialog();
    }

    public void LightingCloud()
    {
        var c = spriteRenderer.color;
        spriteRenderer.color = new Color(c.r, c.g , c.b, 1);
    }

    public void BlackoutCloud()
    {
        var c = spriteRenderer.color;
        spriteRenderer.color = new Color(c.r, c.g, c.b, 0.3f);
    }
    
}
