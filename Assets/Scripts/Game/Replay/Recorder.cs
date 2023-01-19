using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour {
    [SerializeField] private GameObject prefab;
    public Queue< ICommand > recordingQueue { get; private set; }
    private Recording recording;
    private bool isReplaying = false;

    private void Awake() {
        recordingQueue = new Queue< ICommand >();
    }

    private void FixedUpdate() {
        if ( Input.GetKeyDown( KeyCode.R ) ){
            StartReplay();
        }
        if ( !isReplaying ) {
            return;
        }

        recording.PlayNextFrame();
    }

    public void RecordFrame( ICommand data ) {
        recordingQueue.Enqueue( data );
    }

    private void StartReplay() {
        isReplaying = true;
        recording = new Recording( recordingQueue );
        recording.InstantiateObj( prefab );
    }
}
