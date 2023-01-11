using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private CircleCollider2D plrCollider;
    private SpriteRenderer plrRenderer;
    private InputReader inputReader;
    private Recorder recorder;

    private Vector2 spawnPoint;

    Vector2 moveDirection;
    bool isFocusing;

    private void Start() {
        plrCollider = GetComponent< CircleCollider2D >();
        plrRenderer = GetComponent< SpriteRenderer >();
        inputReader = GetComponent< InputReader >();
        recorder = GetComponent< Recorder >();

        spawnPoint = transform.position;
    }

    private void FixedUpdate() {
        if ( plrRenderer.enabled == true && HelperManager.instance.Replaying == false ) {
            Frame currentFrame = new Frame( inputReader.ReadMovement(), inputReader.ReadFocus() );
            
            //var isShootPressed = inputReader.ReadShoot();

            // Move( moveDirection, isFocusPressed );
            ICommand move = new MoveCommand( currentFrame );
            CommandManager.instance.AddFrame( currentFrame );
            
            // doesn't execute if not moving (probably not good if shooting was implemented)
            if ( currentFrame.moveDirection != Vector2.zero ) {
                move.Execute();
            }

            // just to test replay
            var isBombPressed = inputReader.ReadBomb();

            if ( isBombPressed ) {
                // todo: make this pretty from title screen also not like this
                /* transform.position = spawnPoint;
                GameManager.instance.lives = 3;
                CommandManager.instance.isReplaying = true; */
                //CommandManager.instance.Save();
            }
        }
    }

    public void Die() {
        plrRenderer.enabled = false;
        plrCollider.enabled = false;
        // rodo: reduce power to 0
        GameManager.instance.lives -= 1;

        if ( GameManager.instance.lives >= 0 ) {
            GameManager.instance.dead = true;
            StartCoroutine( Respawn() );
        } else {
            if ( HelperManager.instance.Replaying == false ) {
                CommandManager.instance.Save();
            }
            GameManager.instance.EndGame();
        }
    }

    private IEnumerator Respawn() {
        yield return new WaitForSeconds( 1f );
        transform.position = spawnPoint;
        plrRenderer.enabled = true;
        plrCollider.enabled = true;
        GameManager.instance.dead = false;
    }
}
