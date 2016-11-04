using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public PlayerManager playerMg;
    public GameObject enemy;
    public Animator enemyAnim;
    private float delay = 1.0f;

    // Use this for initialization
    void Start ()
    {
        //anim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy collided with player");
            enemyAnim.SetInteger("EnemyState", 3);
            playerMg.jump();
            EdgeCollider2D edgeColl = gameObject.GetComponent<EdgeCollider2D>();
            edgeColl.enabled = false;
           // BoxCollider2D boxColl = gameObject.GetComponent<BoxCollider2D>();
            //boxColl.enabled = false;
            Invoke("destroyEnemy", delay);
        }
    }

    void destroyEnemy()
    {
        //Destroy(gameObject);
        enemy.gameObject.SetActive(false);
    }
}
