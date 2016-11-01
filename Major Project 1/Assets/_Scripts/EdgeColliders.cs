using UnityEngine;
using System.Collections;

public class EdgeColliders : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;
    AudioSource[] audioSrcs;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //if Player collides with one of the two edge colliders, set Animation state to 0 (idle), zero Player's velocity, and stop all audio clips
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            anim = coll.gameObject.GetComponent<Animator>();
            rb2d = coll.gameObject.GetComponent<Rigidbody2D>();
            audioSrcs = coll.gameObject.GetComponents<AudioSource>();
            anim.SetInteger("State", 0);

            //zero player's velocity
            rb2d.velocity = new Vector2(0, 0);

            //stop audio clips
            foreach (AudioSource audio in audioSrcs)
                audio.Stop();
        }
    }
}
