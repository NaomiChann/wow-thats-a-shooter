using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Collidable {
    public Vector2 direction = new Vector2( 0, 1 );
    public int speed = 5;
    private int drop;

    private void Awake() {
        Destroy( gameObject, 1 );
        Random.InitState( 1337 );
        drop = Random.Range( 0, 3 );
    }

    private void FixedUpdate() {
        transform.Translate( direction * speed * Time.fixedDeltaTime * 5 );
    }
    
    protected override void OnCollide( Collider2D collider ) {
        if ( collider.gameObject.CompareTag( "Enemy" ) ) {
            switch ( drop ) {
                case 0:
                    break;
                case 1:
                    Instantiate( GameManager.instance.drop, collider.transform.position, Quaternion.identity );
                    break;
                case 2:
                    Instantiate( GameManager.instance.drop2, collider.transform.position, Quaternion.identity );
                    break;
                default:
                    break;
            }
            Destroy( collider.gameObject );
        }
    }
}