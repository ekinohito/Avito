using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject levelInstancePoint;
    public GameObject animatedCamera;

    private GameObject currentInstance;

    public void SelectLevel(int newLevel)
    {
        if (currentInstance != null) {
            Destroy(currentInstance);
        }
        currentInstance = Instantiate(levels[newLevel], levelInstancePoint.GetComponent<Transform>());
        Debug.Log(animatedCamera.GetComponent<Animation>().Play("CameraToLevel"));
    }

    public void ReturnToMenu()
    {
        animatedCamera.GetComponent<Animation>().Play("LevelToCamera");
    }
}
