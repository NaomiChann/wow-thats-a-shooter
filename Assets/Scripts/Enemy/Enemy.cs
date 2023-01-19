using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Bullet bullet;
    Player target;
    bool delay = true;
    Vector2 direction;

    private void Awake() {
        direction = transform.position;
    }

    private void FixedUpdate() {
        if ( delay == true ) {
            delay = false;
            StartCoroutine( ShootInterval() );
        }

        if ( transform.position.x >= 4 || transform.position.x <= -4 ) {
            direction = direction * -1;
        }
        transform.Translate( direction * Time.fixedDeltaTime );
    }
    
    public void Shoot() {
        Instantiate( bullet.gameObject, transform.position, Quaternion.identity );
        //Bullet bulletObj = obj.GetComponent< Bullet >();
        //bulletObj.transform.rotation = transform.rotation;
    }

    private IEnumerator ShootInterval() {
        for ( int i = 0; i < 30; i++ ) {
            yield return new WaitForFixedUpdate();
        }
        for ( int j = 0; j < 5; j++ ) {
            for ( int i = 0; i < 5; i++ ) {
                yield return new WaitForFixedUpdate();
            }
            Shoot();
        }
        delay = true;
    }
}
