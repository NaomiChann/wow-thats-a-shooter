using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable {
    protected override void OnCollide( Collider2D collider ) {
        if ( collider.gameObject.CompareTag( "Player" ) ) {
            OnHit();
        }
    }

    protected virtual void OnHit() {
        GameManager.instance.KillPlayer();
    }
}
