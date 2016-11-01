using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = true;

    [HideInInspector]
    public bool isGrounded = false;

    //Enemy's max speed
    public float enemySpeed = 1.0f;

    public LayerMask groundLayers;
    public GameObject enemyGroundCheck;

    private float groundCheckRadius = 0.73f;

    Animator anim;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start ()
    {
        //get Animator and RigidBody2D from Enemy
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        //initial animation is idle, EnemyState 0
        anim.SetInteger("EnemyState", 0);

        //zero player's velocity
        rb2d.velocity = new Vector2(0, 0);
    }
	
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(enemyGroundCheck.transform.position, groundCheckRadius, groundLayers);
        if (isGrounded)
            anim.SetInteger("EnemyState", 0);
    }

    // Update is called once per frame
    void Update ()
    {
      
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        anim.SetInteger("EnemyState", 2);
    }
}
