using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Collidable {
    public Vector2 direction = new Vector2( 0, 1 );
    public int speed = 5;

    private void Awake() {
        Destroy( gameObject, 1 );
    }

    private void FixedUpdate() {
        transform.Translate( direction * speed * Time.deltaTime * 5 );
    }
    
    protected override void OnCollide( Collider2D collider ) {
        if ( collider.gameObject.CompareTag( "Enemy" ) ) {
            Destroy( collider.gameObject );
        }
    }
}