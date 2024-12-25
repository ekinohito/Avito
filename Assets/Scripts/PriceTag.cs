using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class PriceTag : MonoBehaviour
{
    public float askedPrice = 100f;
    public float realPrice = 110f;
    public float changeRate = 1f;


    private float outlineWidth = 0f;
    private Material textMaterial;

    private float displayPrice;
    private float displayRealPrice;
    private TextMeshPro text;
    private bool pressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMaterial = gameObject.GetComponent<Renderer>().material;
        text = gameObject.GetComponent<TextMeshPro>();
        displayPrice = askedPrice;
        displayRealPrice = realPrice;
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (displayPrice < askedPrice) {
            displayPrice = Mathf.Clamp(displayPrice + changeRate, displayPrice, askedPrice);
            UpdateDisplay();
        } else if (displayPrice > askedPrice) {
            displayPrice = Mathf.Clamp(displayPrice - changeRate, askedPrice, displayPrice);
            UpdateDisplay();
        }

        if (pressed) {
            if (displayRealPrice < realPrice) {
                displayRealPrice = Mathf.Clamp(displayRealPrice + changeRate, displayRealPrice, realPrice);
                UpdateDisplay();
            } else if (displayRealPrice > realPrice) {
                displayRealPrice = Mathf.Clamp(displayRealPrice - changeRate, realPrice, displayRealPrice);
                UpdateDisplay();
            }
        }

        var outline = textMaterial.GetFloat("_OutlineWidth");
        textMaterial.SetFloat("_OutlineWidth", outline + (outlineWidth - outline) * 0.05f);
    }

    void OnMouseEnter()
    {
        outlineWidth = 0.25f;
    }

    void OnMouseExit()
    {
        outlineWidth = 0f;
    }

    void OnMouseDown()
    {
        pressed = true;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (!pressed) {
            text.text = Mathf.RoundToInt(displayPrice).ToString() + "$";
        } else {
            text.text = FormatPrice(displayRealPrice) + " -\n" + 
                FormatPrice(displayPrice) + " =\n" + FormatPrice(displayRealPrice - displayPrice); 
        }
    }

    public void ChangeRealPrice(float delta)
    {
        if (pressed) {
            return;
        }
        realPrice += delta;
    }

    public void ChangeAskedPrice(float delta)
    {
        if (pressed) {
            return;
        }
        askedPrice += delta;
    }

    public float Profit()
    {
        return realPrice - askedPrice;
    }

    static String FormatPrice(float price) {
        return Mathf.RoundToInt(price).ToString() + "$";
    }
}
