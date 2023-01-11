using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperManager : MonoBehaviour {
    public static HelperManager instance;
    public List< Frame > frames = new List< Frame >();
    private void Awake() {
        if ( HelperManager.instance != null ) {
            Destroy( gameObject );
            return;
        }

        instance = this;
        DontDestroyOnLoad( gameObject );

        frames = FileHandler.ReadFromJSON< Frame >( "Saved.json" );
    }

    public bool Replaying;
}
