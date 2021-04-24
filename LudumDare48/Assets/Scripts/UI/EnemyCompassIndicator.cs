using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompassIndicator : MonoBehaviour
{
    public Transform target;

    private float screenWidth;
    private float screenHeight;

    private void Awake()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Update()
    {
        if (target)
        {
            SetPosition();
        }
    }

    private void SetPosition()
    {
        Debug.DrawLine(target.position, Game.inst.GetPlayerPosition());
        RaycastHit2D[] hits = Physics2D.RaycastAll(target.position, Game.inst.GetPlayerPosition() - target.position);
        Debug.DrawRay(target.position, Game.inst.GetPlayerPosition() - target.position);

        if (hits != null)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.CompareTag(Tags.MainCamTag))
                {
                    transform.position = hit.point;
                }
            }
        }
    }
}
