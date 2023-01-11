using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Frame {
    public Vector2 moveDirection;
    public bool isFocusing;

    public Frame( Vector2 direction, bool focus ) {
        moveDirection = direction;
        isFocusing = focus;
    }
}
