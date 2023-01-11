using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    private void Awake() {
        if ( GameManager.instance != null ) {
            Destroy( gameObject );
            return;
        }

        instance = this;
        //DontDestroyOnLoad( gameObject );
    }

    public Player player;
    public GameObject playerObj;

    public Text scoreValue;
    public Text bombsValue;
    public Text livesValue;

    public int score;
    public int bombs;
    public int lives;

    public int baseSpeed;

    public bool dead;

    private void Update() {
        scoreValue.text = score.ToString() + "00";
        bombsValue.text = bombs.ToString();
        livesValue.text = lives.ToString();
    }

    public void KillPlayer() {
        player.Die();
    }

    public void EndGame() {
        SceneManager.LoadScene( "Title" );
        Destroy( GameObject.FindWithTag( "Helper" ) );
        Destroy( gameObject );
    }
}
