using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkeletonCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("DisplayFinalScoreScene");
        }
    }
}
