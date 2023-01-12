using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCommand : ICommand {
    private GameObject player = GameManager.instance.playerObj;
    private Vector2 direction;
    private bool focusing;
    private bool shooting;
    
    public ControlCommand( Frame frame ) {
        direction = frame.moveDirection;
        focusing = frame.isFocusing;
        shooting = frame.isShooting;
    }

    void ICommand.Execute() {
        int baseSpeed = GameManager.instance.baseSpeed, speed;
        if ( focusing ) {
            speed = baseSpeed / 2;
        } else {
            speed = baseSpeed;
        }

        // change position based on vector
        player.transform.Translate( direction * speed * Time.deltaTime );

        if ( shooting ) {
            GameManager.instance.PlayerShoot();
        }
    }
}
