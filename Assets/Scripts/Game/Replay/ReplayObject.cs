using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayObject : MonoBehaviour {
    public void SetDataForFrame( ICommand data ) {
        data.Execute();
    }
}
