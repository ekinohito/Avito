using UnityEngine;
using UnityEngine.Events;

public class Radio6 : MonoBehaviour
{
    public Dial[] dials;
    public UnityEvent updateGoal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGoal() 
    {
        foreach (var dial in dials) {
            if (dial.desiredPosition != dial.position) {
                return;
            }
        }

        updateGoal.Invoke();
    }
}
