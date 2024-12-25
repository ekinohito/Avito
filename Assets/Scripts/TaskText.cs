using TMPro;
using UnityEngine;

public class TaskText : MonoBehaviour
{
    public PriceTag priceTag;
    public float realPrice = 0f;
    public float askedPrice = -10f;

    private float outlineWidth = 0f;
    private Material textMaterial;
    private bool revealed = false;
    private bool shot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMaterial = gameObject.GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shot || !revealed) {
            return;
        }
        var outline = textMaterial.GetFloat("_OutlineWidth");
        textMaterial.SetFloat("_OutlineWidth", outline + (outlineWidth - outline) * 0.05f);
    }

    void OnMouseEnter()
    {
        if (shot || !revealed) {
            return;
        }
        outlineWidth = 0.25f;
    }

    void OnMouseExit()
    {
        if (shot || !revealed) {
            return;
        }
        outlineWidth = 0f;
    }

    void OnMouseDown()
    {
        if (shot || !revealed) {
            return;
        }
        shot = true;
        gameObject.GetComponent<TextMeshPro>().text = "<s>" + gameObject.GetComponent<TextMeshPro>().text + "</s>";
        priceTag.ChangeAskedPrice(askedPrice);
        textMaterial.SetFloat("_OutlineWidth", 0f);
    }

    public void Reveal()
    {
        if (revealed) {
            return;
        }
        gameObject.GetComponent<Renderer>().enabled = true;
        revealed = true;
        priceTag.ChangeRealPrice(realPrice);
    }
}
