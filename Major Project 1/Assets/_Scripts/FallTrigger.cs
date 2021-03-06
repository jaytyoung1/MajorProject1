﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour
{
    public HealthManager healthMg;
    public PlayerManager playerMg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("player collided with the fall break");
            //PlayerPrefs.DeleteAll();
            //PlayerPrefs.DeleteKey("Coins");
            //PlayerPrefs.DeleteKey("Time");
            //PlayerPrefs.DeleteKey("totalScore");
            //PlayerPrefs.DeleteKey("InitialsEntered");
            //SceneManager.LoadScene("GameScene");
            healthMg.decreaseLives(PlayerPrefs.GetInt("Lives"));
            playerMg.deathRestart();
        }
    }
}
