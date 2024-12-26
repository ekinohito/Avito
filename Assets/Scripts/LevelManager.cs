using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int progress = 0;
    public float money = 100;
    public GameObject[] levels;
    public GameObject levelInstancePoint;
    public GameObject animatedCamera;

    private GameObject currentInstance;

    public void SelectLevel(int newLevel)
    {
        if (newLevel > progress) {
            return;
        }
        if (currentInstance != null) {
            Destroy(currentInstance);
        }
        currentInstance = Instantiate(levels[newLevel], levelInstancePoint.GetComponent<Transform>());
        Debug.Log(animatedCamera.GetComponent<Animation>().Play("CameraToLevel"));
    }

    public void ReturnToMenu(float moneyDelta)
    {
        money += moneyDelta;
        animatedCamera.GetComponent<Animation>().Play("LevelToCamera");
    }
}
