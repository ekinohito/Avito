using UnityEngine;

public class Book3 : MonoBehaviour
{
    public TaskText target1;
    public TaskText target2;
    public Animation billSlide;

    public void FindDollar()
    {
        target1.Reveal();
        billSlide.Play();
    }

    public void FindSignature()
    {
        target2.Reveal();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
