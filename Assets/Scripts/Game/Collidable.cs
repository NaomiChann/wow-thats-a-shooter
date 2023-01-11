using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour {
    public ContactFilter2D filter;
    private CircleCollider2D objCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start() {
        objCollider = GetComponent< CircleCollider2D >();
    }

    protected virtual void Update() {
        objCollider.OverlapCollider( filter, hits );
        
        // checks entire array for collision every update
        for ( int i = 0; i < hits.Length; i++ ) {
            if ( hits[i] == null ) {
                continue;
            }

            // collision is happening with hits[i]
            OnCollide( hits[i] );

            // clear hits[i] collision
            hits[i] = null;
        }
    }

    // called for every collision
    protected virtual void OnCollide( Collider2D collider ) {
        // do thing on collision
    }
}
