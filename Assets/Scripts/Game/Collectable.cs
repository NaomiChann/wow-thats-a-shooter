using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable {

    private Vector2 fall = new Vector2( 0, 1 );
    private float speed = 5;
    public int scoreIncrease;

    protected override void OnCollide( Collider2D collider ) {
        // player collides with collectable
        if ( collider.name == "Player" ) {
            OnCollect();
        }
    }

    // behavior on collection
    protected virtual void OnCollect() {
        GameManager.instance.score += scoreIncrease;
        switch ( gameObject.name ) {
            case "DropPower":
            // increase player shooting power
            break;
            case "DropBomb":
            GameManager.instance.bombs += 1;
            break;
            case "DropLife":
            GameManager.instance.lives += 1;
            break;
            default:
            break;
        }

        Destroy( gameObject );
    }

    private void FixedUpdate() {
        speed -= 0.1f;
        speed = Mathf.Clamp( speed, -5, 5 );
        transform.Translate( fall * speed * Time.deltaTime );
    }
}
