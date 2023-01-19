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

        if ( HelperManager.instance.Replaying ) {
            replayStatus.gameObject.SetActive( true );
        }
        //DontDestroyOnLoad( gameObject );
    }

    public Player player;
    public GameObject drop;
    public GameObject drop2;
    public GameObject playerObj;

    public Text scoreValue;
    public Text bombsValue;
    public Text livesValue;
    
    public Text replayStatus;

    public Text[] inputs;

    public int score;
    public int power;
    public int bombs;
    public int lives;

    public int baseSpeed;
    public int delay;

    public bool dead;

    private void FixedUpdate() {
        scoreValue.text = score.ToString() + "00";
        bombsValue.text = bombs.ToString();
        livesValue.text = lives.ToString();
        delay++;

    }

    private void Update() {
        if( Input.GetKeyDown( KeyCode.X ) ) {
            EndGame();
        }

        if ( HelperManager.instance.Replaying == true && Input.GetKeyDown( KeyCode.R ) ) {
            HelperManager.instance.Replaying = false;
        }
    }

    public void UpgradePlayer() {
        power++;
        player.Upgrade( power );
    }

    public void KillPlayer() {
        lives -= 1;
        power = 0;
        player.Upgrade( power );
        player.Die();
    }

    public void PlayerShoot() {
        player.Shoot();
    }

    public void EndGame() {
        SceneManager.LoadScene( "Title" );
        Destroy( GameObject.FindWithTag( "Helper" ) );
        Destroy( gameObject );
    }
}
