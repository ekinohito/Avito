using UnityEngine;
using UnityEngine.Events;

public class Dial : MonoBehaviour
{
    public int position = 0;
    public int desiredPosition = 3;
    public UnityEvent updateGoal;

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

    void OnMouseDown() {
        position = (position + 1) % 8;
        animator.SetInteger("Position", position);
        updateGoal.Invoke();
    }
}
