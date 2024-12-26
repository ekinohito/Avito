using UnityEngine;

public class Bag2 : MonoBehaviour
{
    public TaskText target1;
    public TaskText target2;

    private bool logo1 = false;
    private bool logo2 = false;

    public void ReachGoal(string goal)
    {
        switch (goal) {
            case "spot":
                target1.Reveal();
                break;
            case "logo1":
                logo1 = true;
                break;
            case "logo2":
                logo2 = true;
                break;
        }
        if (logo1 && logo2) {
            target2.Reveal();
        }
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
