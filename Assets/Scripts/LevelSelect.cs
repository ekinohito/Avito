using UnityEngine;
using UnityEngine.Events;

public class LevelSelect : MonoBehaviour
{
    public UnityEvent SelectLevel;

    void OnMouseDown()
    {
        SelectLevel.Invoke();
    }
}
