using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    private bool canBePressed = false;
    private LevelManager levelManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMaterial = gameObject.GetComponent<Renderer>().material;
        text = gameObject.GetComponent<TextMeshPro>();
        displayPrice = askedPrice;
        displayRealPrice = realPrice;
        UpdateDisplay();
        levelManager = GameObject.FindWithTag("MainCamera").GetComponent<LevelManager>();
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
        if (!canBePressed) {
            return;
        }
        pressed = true;
        UpdateDisplay();

        Invoke("ReturnToMenu", 2);
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
        canBePressed = true;
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

    public void ReturnToMenu()
    {
        levelManager.ReturnToMenu(realPrice - askedPrice);
    }

    static string FormatPrice(float price) {
        return Mathf.RoundToInt(price).ToString() + "$";
    }
}
