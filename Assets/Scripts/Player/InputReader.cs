using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour {
    public Vector2 ReadMovement() {
        float x = Input.GetAxisRaw( "Horizontal" );
        float y = Input.GetAxisRaw( "Vertical" );

        if ( x != 0 || y != 0 ) {
            Vector2 direction = new Vector2( x, y );
            return direction;
        }

        return Vector2.zero;
    }

    internal bool ReadFocus() {
        return Input.GetKey( KeyCode.LeftShift );
    }
        
    internal bool ReadShoot() {
        return Input.GetKey( KeyCode.Z );
    }

    internal bool ReadBomb() {
        return Input.GetKey( KeyCode.X );
    }
}
