using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using TMPro;
using UnityEngine;

public class Speechbubble : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject speechbubble;

    public void SetText(string s)
    {
        text.text = s;
    }

    public void SetActive(bool active)
    {
        speechbubble.SetActive(active);
    }

    public void Flip()
    {
        transform.SetScaleX(-transform.localScale.x);
    }
}
