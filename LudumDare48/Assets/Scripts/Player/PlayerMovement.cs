using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private GameInput input;

    private void Awake()
    {
        input = Game.inst.input;
    }

    private void Update()
    {
        
    }
}
