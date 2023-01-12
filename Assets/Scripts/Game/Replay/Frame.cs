using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Frame {
    public Vector2 moveDirection;
    public bool isFocusing;
    public bool isShooting;

    public Frame( Vector2 direction, bool focus, bool shoot ) {
        moveDirection = direction;
        isFocusing = focus;
        isShooting = shoot;
    }
}
