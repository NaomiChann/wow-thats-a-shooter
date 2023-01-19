using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public BulletPlayer bullet;
    Vector2 direction;

    private void Awake() {
        direction = ( transform.localRotation * Vector2.up ).normalized;
    }
    
    public void Shoot() {
        GameObject obj = Instantiate( bullet.gameObject, transform.position, Quaternion.identity );
        BulletPlayer bulletObj = obj.GetComponent< BulletPlayer >();
        bulletObj.transform.rotation = transform.rotation;
    }
}
