using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording {
    public ReplayObject replayObject { get; private set; }
    private Queue< ICommand > replayQueue;

    public Recording( Queue< ICommand > recordingQueue ) {
        this.replayQueue = new Queue<ICommand>( recordingQueue );
    }

    public void PlayNextFrame() {
        if ( replayQueue.Count != 0 ) {
            ICommand data = replayQueue.Dequeue();
            replayObject.SetDataForFrame( data );
        }
    }

    public void InstantiateObj( GameObject prefab ) {
        if ( replayQueue.Count != 0 ) {
            ICommand data = replayQueue.Peek();
            this.replayObject = Object.Instantiate( prefab, Vector2.zero, Quaternion.identity ).GetComponent< ReplayObject >();
        }
    }
}
