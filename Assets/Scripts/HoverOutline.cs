using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    private Outline outline;
    private float outlineWidth = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        outline.OutlineWidth += (outlineWidth - outline.OutlineWidth) * 0.05f;
    }

    void OnMouseEnter()
    {
        outlineWidth = 10f;
    }

    void OnMouseExit()
    {
        outlineWidth = 0f;
    }
}
