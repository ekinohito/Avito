using UnityEngine;

public class VaseDnp : MonoBehaviour
{
    public TaskText taskText;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        animator.Play("Play");
        taskText.Reveal();
    }
}
