using Unity.VisualScripting;
using UnityEngine;

public class Phone1 : MonoBehaviour
{
    public Material material;

    public float ripSpeed = 0.2f;
    public TaskText target;
    private bool ripped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material.SetFloat("_Cutoff", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ripped) {
            var cutoff = material.GetFloat("_Cutoff");
            if (cutoff < 1.0f) {
                var value = cutoff + ripSpeed * Time.deltaTime;
                material.SetFloat("_Cutoff", value);
            } else {
                ripped = false;
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log(material.GetFloat("_Cutoff"));
        gameObject.GetComponent<Renderer>().enabled = false;
        ripped = true;
        target.Reveal();
    }
}
