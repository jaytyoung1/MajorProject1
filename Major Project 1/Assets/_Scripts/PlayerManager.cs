﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight;

    [HideInInspector]
    public bool isJumping = false;

    [HideInInspector]
    public bool isGrounded = false;

    [HideInInspector]
    public bool areArrowsEnabled = true;

    //Player's max speed
    public float maxSpeed = 2.0f;

    //Player's jump force
    public float jumpForce = 675.0f;

    public Transform startPosition;

    public LayerMask groundLayers;
    public GameObject groundCheck;
    //public EdgeCollider2D leftColl;
    //public EdgeCollider2D rightColl;
    public AudioSource walkingAudio;
    public AudioSource jumpAudio;
    public AudioSource die;
    public AudioSource coinAudio;
    public AudioSource levelWinAudio;
    public AudioSource coinSpawnAudio;

    public Text scoreTextBox;

    private float groundCheckRadius = 0.7f;

    Animator anim;
    Rigidbody2D rb2d;

    public EnemyManager enemyMg;
    public HealthManager healthMg;
    //public CoinCounter coinMg;
    //CircleCollider2D coll;

    // Use this for initialization
    void Start ()
    {
        isFacingRight = true;
        //get Animator and RigidBody2D from Player
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        //get the CircleCollider2D from the groundCheck GameObject
        //coll = groundCheck.GetComponent<CircleCollider2D>();

        //initial animation is idle, State 0
        anim.SetInteger("State", 0);

        //zero player's velocity
        rb2d.velocity = new Vector2(0, 0);

        PlayerPrefs.SetInt("Coins", 0);
        //PlayerPrefs.SetInt("Lives", 3);
        //updateLives(livesLeft);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayers);
        //if (isGrounded)
            //Debug.Log("Player is grounded");
        if (!isGrounded)
        {
            //Debug.Log("not grounded, play jump anim");
            walkingAudio.Stop();
            anim.SetInteger("State", 2);
        }

        float move = Input.GetAxis("Horizontal");
        if (move != 0.0f && areArrowsEnabled)
            walk(move);

        if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0)
            reset();

        if ((move > 0.0f && !isFacingRight) || (move < 0.0f && isFacingRight))
            flip();
    }

    // Update is called once per frame
    void Update ()
    {
        //Debug.Log("hearts left: " + livesLeft);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                anim.SetInteger("State", 2);  //NOTE: have to imclude this even tho we set State = 2 in FixedUpdate()
                jump();
        }

        /*
            if user presses Escape key, quit game
        */
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.DeleteKey("Coins");
            //PlayerPrefs.DeleteKey("Time");
            PlayerPrefs.SetInt("Time", 0);
            PlayerPrefs.DeleteKey("totalScore");
            PlayerPrefs.DeleteKey("InitialsEntered");
            PlayerPrefs.DeleteKey("Lives");
            SceneManager.LoadScene("WelcomeScene");
        }
    }

   

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Coin"))
            coinAudio.Play();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Coin"))
        {
            coinAudio.Play();
            Debug.Log("player collided with spawned coin");
            Destroy(coll.gameObject);
            CoinCounter.coinCount += 1;
            PlayerPrefs.SetInt("Coins", CoinCounter.coinCount);
            scoreTextBox.text = "" + PlayerPrefs.GetInt("Coins");
        }

        if (coll.gameObject.CompareTag("Skeleton"))
        {
            levelWinAudio.Play();
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Invoke("goToFinalScoreScene", delay * 3);     
            //StartCoroutine(goToFinalScoreSceneCo());
        }

        //if (coll.gameObject.CompareTag("enemyBoxColl"))
        //if (coll.gameObject.name == "enemyBoxCollider")
        if (coll.gameObject.CompareTag("Enemy") && isGrounded)
        {
            Debug.Log("player collided with enemy");
            anim.SetInteger("State", 3);
            areArrowsEnabled = false;
            rb2d.velocity = new Vector2(0, 0);
            playDieAudio();
            healthMg.decreaseLives(PlayerPrefs.GetInt("Lives"));
            if (PlayerPrefs.GetInt("Lives") > 0)
                //Invoke("deathRestart", delay);
                StartCoroutine(deathRestartCo());
            else
                //Invoke("goToFinalScoreScene", delay);
                StartCoroutine(goToFinalScoreSceneCo());
        }
    }

    public void deathRestart()
    {
        transform.position = startPosition.position;
        anim.SetInteger("State", 0);
        areArrowsEnabled = true;
        enemyMg.attacking = false;
    }

    IEnumerator deathRestartCo()
    {
        yield return new WaitForSecondsRealtime(1);
        transform.position = startPosition.position;
        anim.SetInteger("State", 0);
        areArrowsEnabled = true;
        enemyMg.attacking = false;
    }

    //void goToFinalScoreScene()
    //{
    //    SceneManager.LoadScene("DisplayFinalScoreScene");
    //}

    IEnumerator goToFinalScoreSceneCo()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("DisplayFinalScoreScene");
    }

    void restartScene()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("totalScore");
        PlayerPrefs.DeleteKey("InitialsEntered");
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("GameScene");
    }

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

    /*
        walk() sets Animation state to 1 (walking), plays audio clip, flips Player if necessary, and updates velo
    */
    void walk(float move)
    {

        if (isGrounded)
            anim.SetInteger("State", 1);
        playWalkingAudio();
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
    }

    public void jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(new Vector2(0, jumpForce));
        playJumpAudio();
    }

    public void killEnemy()
    {
    
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(new Vector2(0, (jumpForce/2) + 100));
        //playJumpAudio();
        coinSpawnAudio.Play();
    }

    /*
        reset() resets Player by setting Animation state to 0 (idle)
    */
    void reset()
    {
        walkingAudio.Stop();
        anim.SetInteger("State", 0);
    }

    void playWalkingAudio()
    {
        if (anim.GetInteger("State") == 1 && !walkingAudio.isPlaying && isGrounded)
        {
            //running.Stop();
            walkingAudio.Play();
        }
    }

    void playJumpAudio()
    {
        if (anim.GetInteger("State") == 2)
        {
            walkingAudio.Stop();
            jumpAudio.Play();
        }
    }

    void playDieAudio()
    {
        if (anim.GetInteger("State") == 3)
        {
            walkingAudio.Stop();
            if (!die.isPlaying)
                die.Play();
        }
    }
}