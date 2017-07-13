using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutInven : MonoBehaviour {

    public GameObject[] Inventory;
    bool Fade_run;

    public void FadeOut()
    {
        for(int i = 0; i<5;i++)
        {
            Inventory[i].SetActive(true);
            Color c = new Color(255, 255, 255);
            Inventory[i].GetComponent<Image>().color = c;
        }
        if (Fade_run)
            StopAllCoroutines();
        StartCoroutine(Fade(Inventory));
    }

    IEnumerator Fade(GameObject[] Target)
    {
        Fade_run = true;
        yield return new WaitForSeconds(5f);

        Color c = new Color(255, 255, 255);
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            c.a = f;
            Target[0].GetComponent<Image>().color = c;
            Target[1].GetComponent<Image>().color = c;
            Target[2].GetComponent<Image>().color = c;
            Target[3].GetComponent<Image>().color = c;
            Target[4].GetComponent<Image>().color = c;
            yield return null;
        }
        c.a = 0;
        Target[0].GetComponent<Image>().color = c;
        Target[1].GetComponent<Image>().color = c;
        Target[2].GetComponent<Image>().color = c;
        Target[3].GetComponent<Image>().color = c;
        Target[4].GetComponent<Image>().color = c;
        Target[0].SetActive(false);
        Target[1].SetActive(false);
        Target[2].SetActive(false);
        Target[3].SetActive(false);
        Target[4].SetActive(false);
    }
    

}