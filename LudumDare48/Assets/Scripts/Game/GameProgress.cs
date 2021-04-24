using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public float irrationality = 0f;

    public void AddIrrationality(float value)
    {
        irrationality += value;
    }
    
    public void ResetProgress()
    {
        irrationality = 0f;
    }
}
