using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject focus;
    public GameObject[] arrays;
    private CircleCollider2D plrCollider;
    private SpriteRenderer plrRenderer;
    private InputReader inputReader;
    private Recorder recorder;

    private Vector2 spawnPoint;

    private Vector2 moveDirection;
    private bool isFocusing;

    Cannon[] cannons;

    private void Awake() {
        plrCollider = GetComponent< CircleCollider2D >();
        plrRenderer = GetComponent< SpriteRenderer >();
        inputReader = GetComponent< InputReader >();
        recorder = GetComponent< Recorder >();

        spawnPoint = transform.position;
        Upgrade( 0 );
    }

    private void FixedUpdate() {
        if ( plrRenderer.enabled == true && HelperManager.instance.Replaying == false ) {
        //if ( plrRenderer.enabled == true ) {
            Frame currentFrame = new Frame( inputReader.ReadMovement(), inputReader.ReadFocus(), inputReader.ReadShoot() );
            
            ICommand action = new ControlCommand( currentFrame );
            CommandManager.instance.AddFrame( currentFrame );
            
            action.Execute();
        }
    }

    public void Die() {
        plrRenderer.enabled = false;
        plrCollider.enabled = false;
        focus.SetActive( false );

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

    public void Shoot() {
        if ( GameManager.instance.delay > 5 ) {
            foreach ( Cannon cannon in cannons ) {
                cannon.Shoot();
            }
            GameManager.instance.delay = 0;
        }
    }

    public void Upgrade( int level ) {
        switch ( level ) {
            case 0:
                arrays[0].SetActive( true );
                arrays[1].SetActive( false );
                arrays[2].SetActive( false );
                break;
            case 1:
                arrays[1].SetActive( true );
                break;
            case 2:
                arrays[2].SetActive( true );
                break;
            default:
                break;
        }
        cannons = transform.GetComponentsInChildren< Cannon >();
    }

    private IEnumerator Respawn() {
        for ( int i = 0; i < 30; i++ ) {
            yield return new WaitForFixedUpdate();
        }
        transform.position = spawnPoint;
        plrRenderer.enabled = true;
        plrCollider.enabled = true;
        focus.SetActive( true );
        GameManager.instance.dead = false;
    }
}
