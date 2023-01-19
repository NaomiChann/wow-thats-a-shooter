using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable {
    public Vector2 direction;
    public int speed = 5;
    Player target;

    private void Awake() {
        Destroy( gameObject, 1 );
        target = GameObject.FindObjectOfType< Player >();
        direction = ( target.transform.position - transform.position ).normalized;
    }

    private void FixedUpdate() {
        transform.Translate( direction * speed * Time.fixedDeltaTime * 2 );
    }
    protected override void OnCollide( Collider2D collider ) {
        if ( collider.gameObject.CompareTag( "Player" ) ) {
            OnHit();
        }
    }

    protected virtual void OnHit() {
        GameManager.instance.KillPlayer();
    }
}
