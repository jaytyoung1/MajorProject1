using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = false;

    [HideInInspector]
    public bool isGrounded = false;

    //public LayerMask groundLayers;
    //public GameObject enemyGroundCheck;

    private float groundCheckRadius = 0.73f;

    private float leftLimit = -1.9f;
    private float rightLimit = 1.9f;
    public float speed = 1.5f;
    private int direction = 1;

    public Animator[] enemyAnimators;
    public Rigidbody2D[] enemyRigidBodys;

   // Animator anim;
   // Rigidbody2D rb2d;

    // Use this for initialization
    void Start ()
    {
        //get Animator and RigidBody2D from Enemy
        //anim = GetComponent<Animator>();
        //rb2d = GetComponent<Rigidbody2D>();

       
        //anim.SetInteger("EnemyState", 1);

        foreach (Animator anim in enemyAnimators)
        {
            //initial animation is idle, EnemyState 0
            anim.SetInteger("EnemyState", 0);
        }

        foreach (Rigidbody2D rb2d in enemyRigidBodys)
        {
            //zero each enemy's velocity
            rb2d.velocity = new Vector2(0, 0);
        }
    }
	
    void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(enemyGroundCheck.transform.position, groundCheckRadius, groundLayers);
        //if (isGrounded)
        //    anim.SetInteger("EnemyState", 1);
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1;
            isFacingRight = false;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
            isFacingRight = true;
        }
        //rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);

    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("collision");
    //        anim.SetInteger("EnemyState", 2);
    //        rb2d.velocity = new Vector2(0, 0);
    //    }
    //}

    /*
       flip() flips the isFacingRight boolean, then negates the player's x transform
   */
    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }
}
