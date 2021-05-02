using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;
using UnityEngine.UI;

public class IrrationalityMeter : MonoBehaviour
{
    public Image fillImage;

    public void UpdateFill()
    {
        SetFill(Game.inst.progress.irrationality);
    }
    
    public void SetFill(float value)
    {
        fillImage.fillAmount = value;

        if (value >= 1f)
        {
            fillImage.color.SetR(0.5f);
        }
    }
}
