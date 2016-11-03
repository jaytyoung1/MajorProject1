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
    public float enemySpeed = 1.5f;
    private int direction = -1;
    private Vector3 movement;

    public Animator[] enemyAnimators;
    public Rigidbody2D[] enemyRigidBodys;

   // Animator anim;
   // Rigidbody2D rb2d;

    // Use this for initialization
    void Start ()
    {
        enemyAnimators = GetComponentsInChildren<Animator>();
        //enemyRigidBodys= GetComponentsInChildren<Rigidbody2D>();

        foreach (Animator anim in enemyAnimators)     
            anim.SetInteger("EnemyState", 1);
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
            flip();
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
            isFacingRight = true;
            flip();
        }
        movement = Vector3.right * direction * enemySpeed * Time.deltaTime;
        transform.Translate(movement);
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
        foreach (Transform child in transform)
        {
            Vector3 enemyScale = child.localScale;
            enemyScale.x = enemyScale.x * -1;
            child.localScale = enemyScale;
        }
    }
}
