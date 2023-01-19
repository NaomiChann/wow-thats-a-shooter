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
            GameManager.instance.inputs[4].gameObject.SetActive( true );
        } else {
            speed = baseSpeed;
            GameManager.instance.inputs[4].gameObject.SetActive( false );
        }

        // change position based on vector
        player.transform.Translate( direction * speed * Time.fixedDeltaTime );

        if ( shooting ) {
            GameManager.instance.PlayerShoot();
            GameManager.instance.inputs[5].gameObject.SetActive( true );
        } else {
            GameManager.instance.inputs[5].gameObject.SetActive( false );
        }

        if ( direction.x == 1 ) {
            GameManager.instance.inputs[3].gameObject.SetActive( true );
        } else {
            GameManager.instance.inputs[3].gameObject.SetActive( false );
        }
        
        if ( direction.x == -1 ) {
            GameManager.instance.inputs[1].gameObject.SetActive( true );
        } else {
            GameManager.instance.inputs[1].gameObject.SetActive( false );
        }

        if ( direction.y == 1 ) {
            GameManager.instance.inputs[0].gameObject.SetActive( true );
        } else {
            GameManager.instance.inputs[0].gameObject.SetActive( false );
        }
        
        if ( direction.y == -1 ) {
            GameManager.instance.inputs[2].gameObject.SetActive( true );
        } else {
            GameManager.instance.inputs[2].gameObject.SetActive( false );
        }
    }
}
