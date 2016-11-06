using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public PlayerManager playerMg;
    public HealthManager healthMg;
    public GameObject enemy;
    public Animator enemyAnim;
    //private float delay = 1.0f;
    private Vector3 newPosition;

    public GameObject newCoin;

    private bool isEnemyDead = false;

    // Use this for initialization
    void Start ()
    {
        //anim = GetComponentInParent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (isEnemyDead)
        {
            newPosition = gameObject.transform.position;
            newPosition.y = newPosition.y + 2;
            GameObject spawnedCoin = Instantiate(newCoin, newPosition, Quaternion.identity) as GameObject;
            spawnedCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2((Random.Range(-40, 40)), 60.0f));

            //Rigidbody2D rb2d = newCoin.GetComponent<Rigidbody2D>();
            //rb2d.AddForce(new Vector2(0, 675.0f));
            //newCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 675.0f));
            isEnemyDead = false;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy collided with player");
            enemyAnim.SetInteger("EnemyState", 3);
            healthMg.increaseLives(PlayerPrefs.GetInt("Lives"));

            //playerMg.jump();
            playerMg.killEnemy();
            isEnemyDead = true;
            

            EdgeCollider2D edgeColl = gameObject.GetComponent<EdgeCollider2D>();
            edgeColl.enabled = false;

            // BoxCollider2D boxColl = gameObject.GetComponent<BoxCollider2D>();
            //boxColl.enabled = false;

            //Invoke("destroyEnemy", delay);
            StartCoroutine(destroyEnemyCo());
        }
    }

    void destroyEnemy()
    {
        //Destroy(gameObject);
        enemy.gameObject.SetActive(false);
    }

    //void destroyEnemy()
    IEnumerator destroyEnemyCo()
    {
        //Destroy(gameObject);
        yield return new WaitForSecondsRealtime(1);
        enemy.gameObject.SetActive(false);
    }
}
