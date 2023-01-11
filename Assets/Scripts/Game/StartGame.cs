using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public string levelName;
    public bool replay;

    public void LoadLevel() {
        HelperManager.instance.Replaying = replay;
        SceneManager.LoadScene( levelName );
    }
}