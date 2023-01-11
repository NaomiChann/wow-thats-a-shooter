using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand {
    private GameObject player = GameManager.instance.playerObj;
    private Vector2 direction;
    private bool focusing;
    
    public MoveCommand( Frame frame ) {
        this.direction = frame.moveDirection;
        this.focusing = frame.isFocusing;
    }

    void ICommand.Execute() {
        int baseSpeed = GameManager.instance.baseSpeed, speed;
        if ( focusing ) {
            speed = baseSpeed / 2;
        } else {
            speed = baseSpeed;
        }

        // read shoot
        // read bomb

        // change position based on vector
        player.transform.Translate( direction * speed * Time.deltaTime );
    }
}
