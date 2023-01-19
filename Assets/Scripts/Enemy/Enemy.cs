using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Bullet bullet;
    Player target;
    bool delay = true;
    private float speed = 5;
    private float center;

    private void Awake() {
        center = transform.position.y;
    }

    private void FixedUpdate() {
        if ( delay == true ) {
            delay = false;
            StartCoroutine( ShootInterval() );
        }

        Vector2 pos = transform.position;

        if ( pos.x >= 2 || pos.x <= -5 ) {
            speed = -speed;
        }

        pos.x += speed * Time.fixedDeltaTime;

        float sin = Mathf.Sin( pos.x / 1.5f );
        
        pos.y = center + sin;

        transform.position = pos;
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
