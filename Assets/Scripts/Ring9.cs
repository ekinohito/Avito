using UnityEngine;

public class Ring9 : MonoBehaviour
{
    public GameObject gameover;
    public bool kanji1 = false;
    public bool kanji2 = false;
    public bool kanji3 = false;
    public bool kanji4 = false;
    public bool kanji5 = false;


    public void Reveal1()
    {
        kanji1 = true;
        CheckFinish();
    }

    public void Reveal2()
    {
        kanji2 = true;
        CheckFinish();
    }

    public void Reveal3()
    {
        kanji3 = true;
        CheckFinish();
    }

    public void Reveal4()
    {
        kanji4 = true;
        CheckFinish();
    }


    public void Reveal5()
    {
        kanji5 = true;
        CheckFinish();
    }

    void CheckFinish()
    {
        if (kanji1 && kanji2 && kanji3 && kanji4 && kanji5) {
             gameover.SetActive(true);
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
