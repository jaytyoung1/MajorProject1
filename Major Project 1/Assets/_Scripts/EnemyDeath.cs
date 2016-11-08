using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public PlayerManager playerMg;
    public HealthManager healthMg;
    public GameObject enemy;
    public Animator enemyAnim;
    private Vector3 newPosition;

    public GameObject newCoin;

    private bool isEnemyDead = false;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (isEnemyDead)
        {
            enemyAnim.SetInteger("EnemyState", 3);
            newPosition = gameObject.transform.position;
            newPosition.y = newPosition.y + 2;
            GameObject spawnedCoin = Instantiate(newCoin, newPosition, Quaternion.identity) as GameObject;
            spawnedCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2((Random.Range(-40, 40)), 50.0f));

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
            //enemy.GetComponent<BoxCollider2D>().enabled = false;
            //boxColl.enabled = false;
            enemyAnim.SetInteger("EnemyState", 3);
            healthMg.increaseLives(PlayerPrefs.GetInt("Lives"));

            playerMg.killEnemy();
            isEnemyDead = true;
            
            EdgeCollider2D edgeColl = gameObject.GetComponent<EdgeCollider2D>();
            edgeColl.enabled = false;

            // BoxCollider2D boxColl = gameObject.GetComponent<BoxCollider2D>();
            //boxColl.enabled = false;

            StartCoroutine(destroyEnemyCo());
        }
    }

    void destroyEnemy()
    {
        //Destroy(gameObject);
        enemy.gameObject.SetActive(false);
    }

    IEnumerator destroyEnemyCo()
    {
        //Destroy(gameObject);
        yield return new WaitForSecondsRealtime(0.5f);
        enemy.gameObject.SetActive(false);
    }
}
