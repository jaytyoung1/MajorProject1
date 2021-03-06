﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
   This script is attached to the skelton and applies an upward force
   when the player collides with it
*/

public class SkeletonCollider : MonoBehaviour
{
    //skeleton's rigidbody
    Rigidbody2D rb2d;

    public string sceneToLoad;

    private float velo = 10.0f;
    //private float delay = 1.0f;

    // Use this for initialization
    void Start ()
    {
        //get skeleton's rigidbody
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            rb2d.velocity = new Vector2(0, velo);
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(sceneToLoad);
    }
}
