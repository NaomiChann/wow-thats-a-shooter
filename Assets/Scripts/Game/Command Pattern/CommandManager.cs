using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour {
    public static CommandManager instance;
    private List< Frame > frames = new List< Frame >();
    private Queue< Frame > replayBuffer = new Queue< Frame >( HelperManager.instance.frames );
    private void Awake() {
        if ( CommandManager.instance != null ) {
            Destroy( gameObject );
            return;
        }

        instance = this;
        //DontDestroyOnLoad( gameObject );
    }


    /* public void AddCommand( ICommand command ) {
        // for loading later probb
        // commandBuffer.Add( command );
    } */
    

    public void AddFrame( Frame frame ) {
        frames.Add( frame );
    }

    public void Save() {
        FileHandler.SaveToJSON< Frame >( frames, "Saved.json" );
    }

    private void FixedUpdate() {
        if ( replayBuffer.Count > 0 && HelperManager.instance.Replaying == true && GameManager.instance.dead == false ) {
            ICommand replayMovement = new ControlCommand( replayBuffer.Dequeue() );
            replayMovement.Execute();
        }
    }
}
