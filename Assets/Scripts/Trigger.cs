using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;
    public bool deleteAfter = false;
    public bool oneShot = true;

    private bool shot = false;

    void OnMouseDown()
    {
        if (oneShot && shot) {
            return;
        }
        shot = true;
        TriggerEvent.Invoke();

        if (deleteAfter) {
            Destroy(gameObject);
        }
    }
}
