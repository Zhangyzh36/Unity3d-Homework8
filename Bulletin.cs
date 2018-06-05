using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletin : MonoBehaviour {

    private Button button;
    public Text text;
    private int frame = 15;

    // Use this for initialization
    void Start()
    {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ClickEvent);
    }

    IEnumerator rotateIn()
    {
        float x = 0;
        float xy = 120;
        for (int i = 0; i < frame; i++)
        {
            x -= 90f / frame;
            xy -= 120f / frame;
            text.transform.rotation = Quaternion.Euler(x, 0, 0);
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy);
            if (i == frame - 1)
            {
                text.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    IEnumerator rotateOut()
    {
        float x = -90;
        float xy = 0;
        for (int i = 0; i < frame; i++)
        {
            x += 90f / frame;
            xy += 120f / frame;
            text.transform.rotation = Quaternion.Euler(x, 0, 0);
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy);
            if (i == 0)
            {
                text.gameObject.SetActive(true);
            }
            yield return null;
        }
    }


    void ClickEvent()
    {
        if (text.gameObject.activeSelf)
        {
            StartCoroutine(rotateIn());
        }
        else
        {
            StartCoroutine(rotateOut());
        }
        
    }
}
